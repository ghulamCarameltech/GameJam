using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public delegate void OnTapping();
    public static event OnTapping onTap; 

    public delegate void OnBack();
    public static event OnBack onBack; 

    public static bool Enable { get; set; }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(onBack != null)
            {
                onBack();
            }
        }

        if (!Enable) return;

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
