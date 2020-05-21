using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    [Header("UI parts")]
    public Button lockCursorButton;

    private void OnEnable()
    {
        lockCursorButton.onClick.AddListener(LockCursor);
    }

    private void Update()
    {
        if (!Application.isEditor && Cursor.visible == true && Cursor.lockState != CursorLockMode.Locked)
        {
            lockCursorButton.gameObject.SetActive(true);
        }
        else
        {
            lockCursorButton.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        lockCursorButton.onClick.RemoveListener(LockCursor);
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}