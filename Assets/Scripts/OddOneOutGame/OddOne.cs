﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OddOne : MonoBehaviour
{
    
     public delegate void Global();
     public static event Global Change;

	[SerializeField]
	private string nextLevel = "OddOneOutGameToSoundGame";
    private Vector2 _beginPoint;
    private Vector2 _endPoint;
    private Vector2 _currentPoint;

    private RectTransform _rect;

    private GameObject _particle;

    private bool _clicked = false;
    private bool _checkSwipeLeft = false;
    private bool _checkSwipeRight = false;

    public AudioClip GoedGedaan;
    public AudioClip DeRichtingWaarin;

    private void OnEnable()
    {
        _particle = Resources.Load("ParticleEffect") as GameObject;
        _rect = GetComponent<RectTransform>();
        GetComponent<Button>().onClick.AddListener(Click);
        Change += ChangeSprite;
    }

    private void OnDisable()
    {
        Change -= ChangeSprite;
    }

    private void Click()
    {
        if (_clicked) return;
        SoundSystem.playAudio(GoedGedaan);
        StartCoroutine(Turn());
    }

    private void Update()
    {
        if(_checkSwipeRight && _checkSwipeLeft != true)
            CheckSwipe( "right");

        if (_checkSwipeLeft)
            CheckSwipe( "left");
    }

    private void CheckSwipe( string dir )
    {
        #if UNITY_ANDROID
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
                        if(SwipeDirectionCheck(dir))
                            Instantiate(_particle, _currentPoint, Quaternion.Euler(Vector3.zero));
                        break;

                    case TouchPhase.Ended:
                        _endPoint = Input.mousePosition;
                        if (SwipeDirectionCheck("right") && Change != null && _checkSwipeRight && _checkSwipeLeft == false)
                            Change();

                        if (SwipeDirectionCheck("left") && Change != null && _checkSwipeLeft)
                            StartCoroutine(LoadNextLevel());
                        break;
                }
            }
        #endif

        #if UNITY_EDITOR

            if (Input.GetMouseButtonDown(0))
            {
                _beginPoint = Input.mousePosition;
            }

            else if (Input.GetMouseButtonUp(0))
            {
                _endPoint = Input.mousePosition;
                if (SwipeDirectionCheck("right") && Change != null && _checkSwipeRight && _checkSwipeLeft == false)
                    Change();

                if (SwipeDirectionCheck("left") && Change != null && _checkSwipeLeft)
                   StartCoroutine(LoadNextLevel());
            }
        #endif
    }


    private bool SwipeDirectionCheck( string dir)
    {
        if (_beginPoint.x < _endPoint.x && dir == "right") {
            return true;
        } else if (_beginPoint.x > _endPoint.x && dir == "left") {
            return true;
        } else {
            return false;
        }

    }

    private void ChangeSprite()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        int r = Random.Range(1, 18);
        GetComponent<Image>().sprite = Resources.Load("Ex2/" + r.ToString(), typeof(Sprite)) as Sprite;
        _checkSwipeLeft = true;
    }

    private IEnumerator LoadNextLevel()
    {
        Debug.Log("loading new scene");
        yield return new WaitForSeconds(1f);
        Application.LoadLevel(Application.loadedLevel);
    }


    private IEnumerator Turn()
    {
        _clicked = true;
        for (var i = 0; i < 180; i++)
        {
            _rect.Rotate(new Vector3(0, 1, 0));
            yield return new WaitForSeconds(.01f);
        }
        _checkSwipeRight = true;
        SoundSystem.playAudio(DeRichtingWaarin);
    }
}