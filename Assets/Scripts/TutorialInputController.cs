using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInputController : MonoBehaviour
{
    public delegate void OnTapping();
    public static event OnTapping onTap; 

    public delegate void OnBack();
    public static event OnBack onBack; 

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(onBack != null)
            {
                onBack();
            }
        }

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began && onTap != null)
            {
                onTap();
            }
        }

        #if UNITY_EDITOR || UNITY_WEBGL
            if(Input.GetKeyDown(KeyCode.Space) && onTap != null)
            {
                onTap();
            }
        #endif
    }

}
