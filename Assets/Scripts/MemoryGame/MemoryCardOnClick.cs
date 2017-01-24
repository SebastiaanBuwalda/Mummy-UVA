using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCardOnClick : MonoBehaviour {

	[SerializeField]
	private AudioClip winSound;
	[SerializeField]
	private AudioClip startupSound;

	[SerializeField]
	private AudioClip startupSound2;

	[SerializeField]
	private AudioClip firstPairSound;

	[SerializeField]
	private int myCardValue = 1;

	private SpriteRenderer spriteRenderer;

	[SerializeField]
	private Sprite openCardSprite;

	private Sprite cardBack;

	public bool alreadyCompleted = false;

	public bool alreadySelected = false;

	private AudioSource audio;

	private GameObject audioObject;

	void Start()
	{
		
		StartCoroutine (playSecondSound ());
		spriteRenderer = gameObject.GetComponent <SpriteRenderer>();
		cardBack = spriteRenderer.sprite;
		if (myCardValue == 0) {
			Debug.LogError ("myCardValue should never be zero");
		}
		audioObject = MemoryGameManager.audioSourceList [0];
		audio = audioObject.GetComponent<AudioSource> ();
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
			if (MemoryGameManager.myCurrentScore == 2) {
				FirstPair ();
			}
			if (MemoryGameManager.myCurrentScore >= MemoryGameManager.winRequirement && MemoryGameManager.winRequirement != 0) {
				StartCoroutine (WinGame ());

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


	IEnumerator WinGame()
	{
		audio.Stop ();
		audio.PlayOneShot (winSound);
		yield return new WaitForSeconds (winSound.length);
		Application.LoadLevel("memoryDragSentence");

	}

	IEnumerator playSecondSound()
	{
		yield return new WaitForSeconds (startupSound.length);
		audio.Stop ();
		audio.PlayOneShot (startupSound2);
	}

	void FirstPair()
	{
		audio.Stop ();
		audio.PlayOneShot (firstPairSound);
	}

}
