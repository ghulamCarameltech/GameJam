using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public enum ShootType {Perfect, Good, Nice, Missed};

    public static ShootType selectedShootType;

    [SerializeField]
    private UIManager uIManager;

    public static int currentLevelIndex;

    
    [SerializeField]
    private TutorialController tutorialPart1;

    [SerializeField]
    private TutorialController tutorialPart2;

    [SerializeField]
    private TutorialController tutorialPart3;

    void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
        EventManager.OnLevelEnd += HandleLevelEndEvent;
    }

    void OnDisable()
    {
        EventManager.OnLevelEnd -= HandleLevelEndEvent;
    }

    void Start()
    {
        currentLevelIndex = 1;
        LoadLevel();
    }

    public void LoadLevel ()
    {
        if(currentLevelIndex == 4)
        {
            currentLevelIndex = 1;
        }
        if(currentLevelIndex == 1)
        {
            SoundManager.PlayMusic("BackgroundMusic");
        }
        else if(currentLevelIndex == 2)
        {
            SoundManager.PlayMusic("runnerBg");
        }
        else if(currentLevelIndex == 3)
        {
            SoundManager.PlayMusic("stackingBg");
        } 
        SceneManager.LoadScene(string.Format("Scenes/Part_{0}", currentLevelIndex), LoadSceneMode.Single);
    }

    public void StartLevel()
    {
        uIManager.ShowScreen(UIManager.UIs.HUD);
        InputController.Enable = true;

        if(PlayerPrefsManager.GetTutorial())
        {
            if(currentLevelIndex == 1)
            {
                tutorialPart1.ShowTutorial();
            }
            else if(currentLevelIndex == 2)
            {
                tutorialPart2.ShowTutorial();
            }
            else if(currentLevelIndex == 3)
            {
                tutorialPart3.ShowTutorial();
            }
            PlayerPrefsManager.SetTutorial(false);
        }
    }

    private void HandleLevelEndEvent (bool success)
    {      
        float delay = 3f;
        if (success)
        {
            if(currentLevelIndex != 1)
            {
                SoundManager.PlaySound("Win");
            }
            currentLevelIndex++;
        }
        else
        {
            SoundManager.PlaySound("fail");
            currentLevelIndex = 1;
        }

        if(currentLevelIndex == 2)
        {
            delay = 3f;
        }
        else if(currentLevelIndex == 3)
        {
            delay = 2f;
        }
        else
        {
            delay = 0f;
        }
        
        StartCoroutine(WaitAndDo(success,delay));
    }

    private IEnumerator WaitAndDo(bool success, float delay)
     {
         yield return new WaitForSeconds(delay);
        
        if(success)
        {
            uIManager.ShowScreen(UIManager.UIs.Win);
        }
        else
        {
            uIManager.ShowScreen(UIManager.UIs.Lose);
        }       
     }
}
