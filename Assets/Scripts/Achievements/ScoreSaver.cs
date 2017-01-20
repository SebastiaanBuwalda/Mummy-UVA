using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSaver : MonoBehaviour {

	public static int GlobalGameScore = 100;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
}
