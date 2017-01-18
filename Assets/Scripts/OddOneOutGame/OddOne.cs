using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OddOne : MonoBehaviour
{
    private Vector2 _beginPoint;
    private Vector2 _endPoint;


    private RectTransform _rect;

    private void Start()
    {
        _rect = GetComponent<RectTransform>();
        GetComponent<Image>().color = Color.red;
        GetComponent<Button>().onClick.AddListener(Click);
    }

    private void Click()
    {
        Debug.Log("you pressed the right button. Good job!");
        StartCoroutine(Turn());
    }

    private IEnumerator Turn()
    {
        for (var i = 0; i < 180; i++)
        {
            _rect.Rotate(new Vector3(0,1,0));
            yield return new WaitForSeconds(.01f);
        }
    }

    private void CheckSwipe()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _beginPoint = touch.position;
                    break;

                case TouchPhase.Ended:
                    _endPoint = touch.position;
                    break;
            }
        }
    }

    private void SwipeDirectionCheck()
    {
        if(_beginPoint.x < _endPoint.x)
            Debug.Log("We did it Reddit");
    }
}
