using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour {

	[SerializeField]
	private List<Vector2> cardPositions = new List<Vector2>();

	[SerializeField]
	private List<GameObject> cardObjectsList = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		if (cardObjectsList.Count != cardPositions.Count) {
			Debug.LogError ("POSITION AND GAME OBJECTS LIST ARE NOT EQUAL.");
		}
		foreach (GameObject card in cardObjectsList.ToArray()) {
			int listPosition = Random.Range (0, cardObjectsList.Count);
			Instantiate (card, cardPositions[listPosition], Quaternion.identity);
			cardPositions.RemoveAt (listPosition);
			cardObjectsList.RemoveAt (listPosition);
			MemoryGameManager.winRequirement++;
		}
	}
	

}
