using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacterController : MonoBehaviour
{
    [Header("Variables")]
    public float movementSpeed;

    protected Vector2 totalMouseDegrees;

    protected Rigidbody body;

    protected virtual void Awake()
    {
        body = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    protected virtual void Update()
    {
        Vector3 mouseMovement = Vector3.zero;
        if (GameManager.instance.IsInGame())
        {
            mouseMovement = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0.0f);
        }

        if (!Mathf.Approximately(mouseMovement.sqrMagnitude, 0.0f))
        {
            totalMouseDegrees.x += mouseMovement.x * ControlSettings.cameraHorizontalSpeed;
            totalMouseDegrees.y += mouseMovement.y * ControlSettings.cameraVerticalSpeed;
            totalMouseDegrees.y = Mathf.Clamp(totalMouseDegrees.y, -90.0f, 90.0f);

            Camera.main.transform.localRotation = Quaternion.identity;
            Camera.main.transform.Rotate(-totalMouseDegrees.y, 0.0f, 0.0f, Space.Self);
            transform.localRotation = Quaternion.identity;
            transform.Rotate(0.0f, totalMouseDegrees.x, 0.0f, Space.Self);
        }
    }

    protected virtual void FixedUpdate()
    {
        Vector3 airMovement = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            airMovement.z += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            airMovement.z += -1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            airMovement.x += -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            airMovement.x += 1;
        }
        body.AddForce(transform.TransformDirection(airMovement.normalized) * movementSpeed * Time.fixedDeltaTime);
    }
}