using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBack : MonoBehaviour
{
    [SerializeField]
    private Game gameManager;

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
        uIManager.ShowScreen(UIManager.UIs.HUD);
    }

    public void LoadHomeScreen()
    {
        Game.currentLevelIndex = 1;
        gameManager.LoadLevel();
        uIManager.ShowScreen(UIManager.UIs.MainMenu);
    }
}
