﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovie : MonoBehaviour {

    [SerializeField]
    private string MovieTitle;


	// Use this for initialization
	void Start () {
        CutScene();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void CutScene()
    {
        Handheld.PlayFullScreenMovie(MovieTitle, Color.black, FullScreenMovieControlMode.Hidden);
    }
}
