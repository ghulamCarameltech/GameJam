using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerInputController : MonoBehaviour
{
    public enum Direction {Left, Right};

    public delegate void OnMovement(Direction x);
    public static event OnMovement onMove; 

    public delegate void OnBack();
    public static event OnBack onBack; 

    Vector2 _startPosition;
    Vector2 _movePosition;
    Vector2 _endPosition;

    [SerializeField]
    [Range(0.0f, 100.0f)]
    float _movePercentage = 20f;

    public static bool Enable { get; set; }

    bool move;

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

            if(touch.phase == TouchPhase.Began)
            {
                _startPosition = touch.position;
                move = true;
            }
            else if(touch.phase == TouchPhase.Moved && move)
            {
                _movePosition = touch.position;
                float xMoved = _movePosition.x - _startPosition.x;
                float yMoved = _movePosition.y - _startPosition.y;
                bool swipedHorizontal = Mathf.Abs(xMoved) > Mathf.Abs(yMoved);

                float distance = Mathf.Sqrt((xMoved * xMoved) + (yMoved * yMoved));

                bool percentageHorizontal = (distance > ((Screen.width / 100) * _movePercentage));
                bool percentageVertical = (distance > ((Screen.width / 100) * _movePercentage));

                if(percentageHorizontal || percentageVertical)
                {
                    move = false;
                }

                if(swipedHorizontal && xMoved > 0 && percentageHorizontal && onMove != null)
                {
                    onMove(Direction.Right);
                }
                else if(swipedHorizontal && xMoved < 0 && percentageHorizontal && onMove != null)
                {
                    onMove(Direction.Left);
                }
            }
            else if(touch.phase == TouchPhase.Ended && move)
            {
                _endPosition = touch.position;
                float xMoved = _endPosition.x - _startPosition.x;
                float yMoved = _endPosition.y - _startPosition.y;
                bool swipedHorizontal = Mathf.Abs(xMoved) > Mathf.Abs(yMoved);

                float distance = Mathf.Sqrt((xMoved * xMoved) + (yMoved * yMoved));

                bool percentageHorizontal = (distance > ((Screen.width / 100) * _movePercentage));
                bool percentageVertical = (distance > ((Screen.width / 100) * _movePercentage));

                if(swipedHorizontal && xMoved > 0 && percentageHorizontal && onMove != null)
                {
                    onMove(Direction.Right);
                }
                else if(swipedHorizontal && xMoved < 0 && percentageHorizontal && onMove != null)
                {
                    onMove(Direction.Left);
                }
            }
        }

        #if UNITY_EDITOR
            if(Input.GetKeyDown(KeyCode.RightArrow) && onMove != null)
            {
                onMove(Direction.Right);
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow) && onMove != null)
            {
                onMove(Direction.Left);
            }
        #endif
    }

}
