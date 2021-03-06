﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [SerializeField]
    private GameObject matcher;

    private CodeMatcher codeMatcher;
    private bool mouseClick;

    [SerializeField]
    private AudioClip tileSound;

    [SerializeField]
    private AudioSource audio;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        codeMatcher = matcher.gameObject.GetComponent<CodeMatcher>();
        mouseClick = codeMatcher.MouseClick;
    }

    void OnMouseDown() {
        if (mouseClick)
        {
            playSound();
        }
    }

    private void playSound()
    {
        audio.Stop();
        audio.PlayOneShot(tileSound);
    }
}
