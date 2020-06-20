using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UILose : MonoBehaviour
{
    [SerializeField]
    private Game gameManager;

    [SerializeField]
    private UIManager uIManager;

    // [SerializeField]
    // private TextMeshProUGUI _score;

    void OnEnable()
    {
        // _score.text = string.Format("{0}", Level.Score);
        Time.timeScale = 0f;
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void TryAgain()
    {
        gameManager.LoadLevel();
        gameManager.StartLevel();
    }

    public void LoadHomeScreen()
    {
        // gameManager.LoadLevel();
        uIManager.ShowScreen(UIManager.UIs.MainMenu);
    }
}
