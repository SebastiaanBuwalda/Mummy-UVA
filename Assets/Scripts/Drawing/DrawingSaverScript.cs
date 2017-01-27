using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingSaverScript : MonoBehaviour {

	public static List<GameObject> DrawingList = new List<GameObject>();

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	static void SpawnDrawing()
	{
		foreach (GameObject dot in DrawingList) {
			Instantiate (dot);
		}
	}
}
