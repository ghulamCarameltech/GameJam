using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public enum UIs {HUD, MainMenu, Win, Lose, Exit, Setting, Mode, Back};

    private UIs activeScreen;

    [SerializeField]
    private UIHUD uIHUD;

    [SerializeField]
    private UIMainMenu uIMainMenu;

    [SerializeField]
    private UIWin uIWin;

    [SerializeField]
    private UILose uILose;

    [SerializeField]
    private UIExit uIExit;

    [SerializeField]
    private UISetting uISetting;

    [SerializeField]
    private UIMode uIMode;

    [SerializeField]
    private UIBack uIBack;

    // [SerializeField]
    // private TutorialController tutorial;

    void Start()
    {
        ShowScreen(UIs.MainMenu);
    }

    
    void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
        InputController.onBack += UIExitGame;
    }

     void OnDisable()
     {
         InputController.onBack -= UIExitGame;
     }

    public void ShowScreen(UIs uIs)
    {
        CloseScreens();

        switch (uIs)
        {
            case UIs.HUD:
                uIHUD.gameObject.SetActive(true);
            break;
            
            case UIs.MainMenu:
                uIMainMenu.gameObject.SetActive(true);
            break;

            case UIs.Win:
                uIWin.gameObject.SetActive(true);
            break;

            case UIs.Lose:
                uILose.gameObject.SetActive(true);
            break;

            case UIs.Exit:
                uIExit.gameObject.SetActive(true);
            break;

            case UIs.Setting:
                uISetting.gameObject.SetActive(true);
            break;

            case UIs.Mode:
                uIMode.gameObject.SetActive(true);
            break;

            case UIs.Back:
                uIBack.gameObject.SetActive(true);
            break;

            default:

            break;
        }
        activeScreen = uIs;
    }

    void CloseScreens()
    {
        uIHUD.gameObject.SetActive(false);
           
        uIMainMenu.gameObject.SetActive(false);
    
        uIWin.gameObject.SetActive(false);
    
        uILose.gameObject.SetActive(false);

        uIExit.gameObject.SetActive(false);

        uISetting.gameObject.SetActive(false);

        uIMode.gameObject.SetActive(false);

        uIBack.gameObject.SetActive(false);

        // tutorial.gameObject.SetActive(false);
    }

    void UIExitGame()
    {
        if(activeScreen == UIs.MainMenu)
        {
            ShowScreen(UIs.Exit);
        }
    }
}
