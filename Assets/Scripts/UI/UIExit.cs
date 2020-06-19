using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIExit : MonoBehaviour
{

    [SerializeField]
    private UIManager uIManager;

    void OnEnable()
    {
        Time.timeScale = 0f;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void Resume()
    {
        uIManager.ShowScreen(UIManager.UIs.MainMenu);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
