using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMode : MonoBehaviour
{
    //  [SerializeField]
    // private Game gameManager;

    [SerializeField]
    private UIManager uIManager;


    public void LoadHomeScreen()
    {
        uIManager.ShowScreen(UIManager.UIs.MainMenu);
    }
}
