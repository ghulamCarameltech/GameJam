using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private Game gameManager;

    [SerializeField]
    private UIManager uIManager;

    public void PlayButton()
    {
        gameManager.StartLevel();
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
