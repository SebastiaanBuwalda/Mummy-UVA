using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCardOnClick : MonoBehaviour {

	[SerializeField]
	private int myCardValue = 1;

	private SpriteRenderer spriteRenderer;

	[SerializeField]
	private Sprite openCardSprite;

	private Sprite cardBack;

	public bool alreadyCompleted = false;

	public bool alreadySelected = false;

	void Start()
	{
		spriteRenderer = gameObject.GetComponent <SpriteRenderer>();
		cardBack = spriteRenderer.sprite;
		if (myCardValue == 0) {
			Debug.LogError ("myCardValue should never be zero");
		}
	}

	void OnMouseDown()
	{
		if (!alreadySelected) {
			if (MemoryGameManager.ableToClick && !alreadyCompleted) {
				if (MemoryGameManager.mySelection != 0) {
					//selection has already been made
					if (MemoryGameManager.mySelection == myCardValue) {
						StartCoroutine (CompleteCards ());

					} else if (MemoryGameManager.mySelection != myCardValue) {
						StartCoroutine (WrongCards ());
					}

				} else if (MemoryGameManager.mySelection == 0) {
					//no selection made yet...
					spriteRenderer.sprite = openCardSprite;
					MemoryGameManager.mySelection = myCardValue;
					MemoryGameManager.deletionList.Add (this.gameObject);
					alreadySelected = true;

				}
			}
		}
	}

	IEnumerator CompleteCards()
	{
		MemoryGameManager.ableToClick = false;
		yield return new WaitForSeconds (0);

		spriteRenderer.sprite = openCardSprite;
		//found the correct card
		MemoryGameManager.deletionList.Add (this.gameObject);
		foreach (GameObject correctCard in MemoryGameManager.deletionList) {
			correctCard.GetComponent<MemoryCardOnClick> ().alreadyCompleted = true;
			MemoryGameManager.myCurrentScore++;

			if (MemoryGameManager.myCurrentScore >= MemoryGameManager.winRequirement && MemoryGameManager.winRequirement != 0) {
				WinGame ();
			}
		}
		MemoryGameManager.deletionList.Clear ();
		MemoryGameManager.mySelection = 0;
		MemoryGameManager.ableToClick = true;
	}

	IEnumerator WrongCards()
	{
		MemoryGameManager.ableToClick = false;
		spriteRenderer.sprite = openCardSprite;
		yield return new WaitForSeconds (1);
		//found the wrong card
		MemoryGameManager.mySelection = 0;
		foreach (GameObject wrongCard in MemoryGameManager.deletionList) {
			SpriteRenderer wrongCardSR = wrongCard.GetComponent<SpriteRenderer> ();
			wrongCardSR.sprite = cardBack;
			wrongCard.GetComponent<MemoryCardOnClick> ().alreadySelected = false;
		}

		spriteRenderer.sprite = cardBack;

		MemoryGameManager.deletionList.Clear ();
		MemoryGameManager.ableToClick = true;

	}


	void WinGame()
	{
		Debug.Log ("YOU WON");
	}

}
