using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundOnAwake : MonoBehaviour {

	[SerializeField]
	private AudioSource audio;


	[SerializeField]
	private AudioClip clip;

	void Awake()
	{
		audio.Stop ();
		audio.PlayOneShot (clip);
	}
}
