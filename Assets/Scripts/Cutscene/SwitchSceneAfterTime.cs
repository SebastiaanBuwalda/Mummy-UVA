using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSceneAfterTime : MonoBehaviour {

	[SerializeField]
	private int timeToWait = 3;

	[SerializeField]
	private string nextLevel;

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (SwitchScene ());
	}

	IEnumerator SwitchScene()
	{
		yield return new WaitForSeconds (timeToWait);
		Application.LoadLevel(nextLevel);


	}
}
