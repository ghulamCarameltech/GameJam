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
    }

    public void LoadLevel ()
    {
        SceneManager.LoadScene(string.Format("Scenes/Part_{0}", currentLevelIndex), LoadSceneMode.Single);
    }

    public void StartLevel()
    {
        uIManager.ShowScreen(UIManager.UIs.HUD);
        InputController.Enable = true;
    }

    private void HandleLevelEndEvent (bool success)
    {      
        float delay = 3f;
        if (success)
        {
            currentLevelIndex++;
            if (currentLevelIndex > 3) currentLevelIndex = 1;
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
