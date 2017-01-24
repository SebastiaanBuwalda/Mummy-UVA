using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class markMeAsContainer : MonoBehaviour {

	void Awake()
	{
		MemoryGameManager.audioSourceList.Add (gameObject);
	}
}
