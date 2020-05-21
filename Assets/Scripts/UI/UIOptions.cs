using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOptions : MonoBehaviour
{
    [Header("UI parts")]
    public Slider cameraVerticalSpeedSlider;
    public Slider cameraHorizontalSpeedSlider;

    private void OnEnable()
    {
        cameraVerticalSpeedSlider.onValueChanged.AddListener(OnCameraVerticalSpeedChanged);
        cameraHorizontalSpeedSlider.onValueChanged.AddListener(OnCameraHorizontalSpeedChanged);
    }

    public void Initialize()
    {
        cameraVerticalSpeedSlider.value = ControlSettings.cameraVerticalSpeed;
        cameraHorizontalSpeedSlider.value = ControlSettings.cameraHorizontalSpeed;
    }

    public void OnDisable()
    {
        cameraVerticalSpeedSlider.onValueChanged.RemoveListener(OnCameraVerticalSpeedChanged);
        cameraHorizontalSpeedSlider.onValueChanged.RemoveListener(OnCameraHorizontalSpeedChanged);
    }

    public void OnCameraVerticalSpeedChanged(float newValue)
    {
        ControlSettings.cameraVerticalSpeed = newValue;
    }

    public void OnCameraHorizontalSpeedChanged(float newValue)
    {
        ControlSettings.cameraHorizontalSpeed = newValue;
    }
}