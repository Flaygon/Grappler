using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI Objects")]
    public UIGame gameUIObject;
    public UIOptions menuUIObject;

    [Header("Containers")]
    public VFXContainer vfxContainer;

    public bool IsInGame() { return gameUIObject.gameObject.activeSelf; }

    private void Awake()
    {
        // Do we already have an instance of this?
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void OnEnable()
    {
        InputManager.OnEscapePressed += ToggleMenuUI;
    }

    private void OnDisable()
    {
        InputManager.OnEscapePressed -= ToggleMenuUI;
    }

    private void ToggleMenuUI()
    {
        if (IsInGame())
        {
            OpenMenuUI();
        }
        else
        {
            CloseMenuUI();
        }
    }

    private void OpenMenuUI()
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        gameUIObject.gameObject.SetActive(false);
        menuUIObject.gameObject.SetActive(true);

        menuUIObject.Initialize();
    }

    private void CloseMenuUI()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        gameUIObject.gameObject.SetActive(true);
        menuUIObject.gameObject.SetActive(false);
    }
}