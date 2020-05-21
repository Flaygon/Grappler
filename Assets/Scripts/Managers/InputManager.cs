using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static System.Action OnForward;
    public static System.Action OnBackward;
    public static System.Action OnLeft;
    public static System.Action OnRight;

    public static System.Action OnLeftMouseButtonPressed;
    public static System.Action OnLeftMouseButtonDepressed;

    public static System.Action OnSpacePressed;
    public static System.Action OnSpacePressing;
    public static System.Action OnSpaceDepressed;

    public static System.Action OnEscapePressed;

    public void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            OnForward?.Invoke();
        }
        if (Input.GetKey(KeyCode.S))
        {
            OnBackward?.Invoke();
        }
        if (Input.GetKey(KeyCode.A))
        {
            OnLeft?.Invoke();
        }
        if (Input.GetKey(KeyCode.D))
        {
            OnRight?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacePressed?.Invoke();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            OnSpacePressing?.Invoke();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            OnSpaceDepressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscapePressed?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            OnLeftMouseButtonPressed?.Invoke();
        }
        if (Input.GetMouseButtonUp(0))
        {
            OnLeftMouseButtonDepressed?.Invoke();
        }
    }
}