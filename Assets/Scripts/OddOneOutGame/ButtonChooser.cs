﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChooser : MonoBehaviour
{
    private readonly List<GameObject> _buttons = new List<GameObject>();

    [SerializeField]
    private AudioSource _ietsLijktNiet;

    private void Awake ()
	{
        _ietsLijktNiet.Play();
	    ChooseOddOne();
	}

    private void ChooseOddOne()
    {
        foreach (Transform child in transform)
        {
            _buttons.Add(child.gameObject);
        }
        var n = Random.Range(0, _buttons.Count);

        Destroy(_buttons[n].GetComponent("RegularOne"));
        _buttons[n].AddComponent<OddOne>();
    }
}
