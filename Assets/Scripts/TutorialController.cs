using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    void OnDisable()
    {
       
        InputController.onTap -= HideTutorial;
        RunnerInputController.onMove -= HideTutorialSwipe;
    }

    public void ShowTutorial()
    {
        gameObject.SetActive(true);
        if(Game.currentLevelIndex == 1 || Game.currentLevelIndex == 3)
        {
            InputController.onTap += HideTutorial;
        }
        else
        {
            RunnerInputController.onMove += HideTutorialSwipe;
        }
    }

    public void HideTutorial()
    {
        gameObject.SetActive(false);
    }

    public void HideTutorialSwipe(RunnerInputController.Direction direction)
    {
        gameObject.SetActive(false);
    }

}
