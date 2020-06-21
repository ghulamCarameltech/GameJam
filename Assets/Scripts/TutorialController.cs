using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    void OnDisable()
    {
        TutorialInputController.onTap -= HideTutorial;
        PlayerPrefsManager.SetTutorial(false);
    }

    void OnEnable()
    {
        InputController.Enable = false;
        RunnerInputController.Enable = false;
    }

    public void ShowTutorial()
    {
        gameObject.SetActive(true);
        
        TutorialInputController.onTap += HideTutorial;
    }

    public void HideTutorial()
    {
        gameObject.SetActive(false);
        Invoke("EnableController",0.2f);
    }

    public void HideTutorialSwipe(RunnerInputController.Direction direction)
    {
        gameObject.SetActive(false);
    }

    void EnableController()
    {
        InputController.Enable = true;
        RunnerInputController.Enable = true;
    }

}
