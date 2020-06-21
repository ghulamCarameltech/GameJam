using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private Game gameManager;

    [SerializeField]
    private UIManager uIManager;

    [SerializeField]
    private TextMeshProUGUI _highScore;
    

    public void PlayButton()
    {
        gameManager.StartLevel();
    }

    void OnEnable() {
        int highScore = PlayerPrefs.GetInt("HighScore",0);
        _highScore.text = string.Format("High Score: {0}",highScore);
    }
    public void ModesButton()
    {
        uIManager.ShowScreen(UIManager.UIs.Mode);
    }

    public void SettingButton()
    {
        uIManager.ShowScreen(UIManager.UIs.Setting);
    }
}
