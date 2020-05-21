using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookComponent : MonoBehaviour
{
    [Header("Scene Objects")]
    public Rigidbody body;

    [Header("Prefabs")]
    public GameObject hookAnchorPrefab;
    public GameObject hookLinePrefab;
    private GameObject hookAnchorInstance;
    private GameObject hookLineInstance;

    [Header("Variables")]
    public float anchorPullForce = 65.0f;

    private Vector3 anchorPoint;
    private bool holdingDownPull = false;

    private void Awake()
    {
        hookAnchorInstance = Instantiate(hookAnchorPrefab);
        hookLineInstance = Instantiate(hookLinePrefab);

        Deactivate();
    }

    private void OnEnable()
    {
        InputManager.OnLeftMouseButtonPressed += TryActivate;
        InputManager.OnLeftMouseButtonDepressed += Deactivate;
    }

    private void OnDisable()
    {
        InputManager.OnLeftMouseButtonPressed -= TryActivate;
        InputManager.OnLeftMouseButtonDepressed -= Deactivate;
    }

    private void Update()
    {
        if (holdingDownPull)
        {
            // Figure out position in space
            Vector3 distance = anchorPoint - transform.position;
            hookLineInstance.transform.position = transform.position + distance * 0.5f;

            // Make it align Z towards target
            hookLineInstance.transform.localRotation = Quaternion.identity;
            hookLineInstance.transform.LookAt(anchorPoint);

            // Rotate it so we get a better view of it
            hookLineInstance.transform.Rotate(0.0f, 0.0f, 45.0f);

            // Stretch Z to cover up the distance, but keep the original X, Y scaling
            Vector3 stretchedScale = hookLineInstance.transform.localScale;
            stretchedScale.z = distance.magnitude;
            hookLineInstance.transform.localScale = stretchedScale;
        }
    }

    private void TryActivate()
    {
        // We don't want to activate the hook if we're not currently steering our character
        if(!GameManager.instance.IsInGame())
        {
            return;
        }

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f)), out hit, 2000, LayerMask.GetMask("Environment"), QueryTriggerInteraction.Ignore))
        {
            anchorPoint = hit.point;
            hookAnchorInstance.transform.position = anchorPoint;
            hookAnchorInstance.SetActive(true);
            hookLineInstance.SetActive(true);
            holdingDownPull = true;
        }
    }

    private void Deactivate()
    {
        holdingDownPull = false;
        hookAnchorInstance.SetActive(false);
        hookLineInstance.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (holdingDownPull)
        {
            body.useGravity = false;
            body.AddForce((anchorPoint - transform.position).normalized * anchorPullForce);
        }
        else
        {
            body.useGravity = true;
        }
    }
}