using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OddOne : MonoBehaviour
{

	[SerializeField]
	private string nextLevel = "OddOneOutGameToSoundGame";
    private Vector2 _beginPoint;
    private Vector2 _endPoint;
    private Vector2 _currentPoint;

    private RectTransform _rect;

    private GameObject _particle;

    private bool _checkSwipe = false;

    public AudioSource goedGedaan;


    private void Start()
    {
        _particle = Resources.Load("Prefabs/ParticleEffect") as GameObject;
        _rect = GetComponent<RectTransform>();
        GetComponent<Button>().onClick.AddListener(Click);
    }

    private void Click()
    {
        Debug.Log("you pressed the right button. Good job!");
        goedGedaan.Play();
        StartCoroutine(Turn());
    }

    private IEnumerator Turn()
    {
        for (var i = 0; i < 180; i++)
        {
            _rect.Rotate(new Vector3(0,1,0));
            yield return new WaitForSeconds(.01f);
        }
        _checkSwipe = true;
        yield return new WaitForSeconds(1f);
        Application.LoadLevel(nextLevel);
    }

    private void Update()
    {
        if(_checkSwipe)
            CheckSwipe();
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

                case TouchPhase.Moved:
                    _currentPoint = touch.position;
                    if(_currentPoint.x > _beginPoint.x)
                        Instantiate(_particle, _currentPoint, Quaternion.Euler(Vector3.zero));
                    break;

                case TouchPhase.Ended:
                    _endPoint = touch.position;
                    break;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mousebuttondown");
            _beginPoint = Input.mousePosition;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("mousebutton up");
            _endPoint = Input.mousePosition;
            SwipeDirectionCheck();
        }
    }
    

    private void SwipeDirectionCheck()
    {
        if (_beginPoint.x < _endPoint.x)
        {
            Debug.Log("We did it Reddit");
        }
    }
}
