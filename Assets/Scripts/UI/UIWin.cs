using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIWin : MonoBehaviour
{
    // [SerializeField]
    // private Game gameManager;

    [SerializeField]
    private UIManager uIManager;

    [SerializeField]
    private TextMeshProUGUI _score;

    void OnEnable()
    {
        // _score.text = string.Format("{0}", Level.Score);
        Time.timeScale = 0f;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void Continue()
    {
        uIManager.ShowScreen(UIManager.UIs.HUD);
        InputController.Enable = true;
    }

    public void LoadNextLevel()
    {
        // gameManager.LoadLevel();
        // gameManager.StartLevel();
    }

    public void LoadHomeScreen()
    {
        // gameManager.LoadLevel();
        uIManager.ShowScreen(UIManager.UIs.MainMenu);
    }
}
