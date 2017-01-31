using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeMatcher : MonoBehaviour {

    [SerializeField]
    private GameObject box1;
    [SerializeField]
    private GameObject box2;
    [SerializeField]
    private GameObject box3;
    [SerializeField]
    private GameObject box4;

    private int box1Code;
    private int box2Code;
    private int box3Code;
    private int box4Code;

    [SerializeField]
	private int gameMode = 3;

    private string boxCodeCombination;

    private bool allFilled;

	[SerializeField]
    private string correctCode = "345";

	[SerializeField]
	private string nextLevelCode = "";

    [SerializeField]
    private AudioClip correctSound;
    [SerializeField]
    private AudioClip correctSound1;
    [SerializeField]
    private AudioClip correctSound2;

    [SerializeField]
    private AudioClip wrongSound;

    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private int timeToWait;

    private bool mouseClick = true;

    private bool wrongAwnser = false;

    private bool playOnce = false;

    // Update is called once per frame
    void Update () {

        if (gameMode == 4)
        {
            box1Code = box1.gameObject.GetComponent<CheckOverTarget>().TileNumber;
            box2Code = box2.gameObject.GetComponent<CheckOverTarget>().TileNumber;
            box3Code = box3.gameObject.GetComponent<CheckOverTarget>().TileNumber;
            box4Code = box4.gameObject.GetComponent<CheckOverTarget>().TileNumber;

            boxCodeCombination = box1Code.ToString() + box2Code.ToString() + box3Code.ToString() + box4Code.ToString();
        }
        else if (gameMode == 2)
        {
            box1Code = box1.gameObject.GetComponent<CheckOverTarget>().TileNumber;
            box2Code = box2.gameObject.GetComponent<CheckOverTarget>().TileNumber;

            boxCodeCombination = box1Code.ToString() + box2Code.ToString();
        }
        else if (gameMode == 3)
        {
            box1Code = box1.gameObject.GetComponent<CheckOverTarget>().TileNumber;
            box2Code = box2.gameObject.GetComponent<CheckOverTarget>().TileNumber;
            box3Code = box3.gameObject.GetComponent<CheckOverTarget>().TileNumber;

            boxCodeCombination = box1Code.ToString() + box2Code.ToString() + box3Code.ToString();
        }

        CheckBox();
        CheckAwnser();
    }

    /// CHECKS IF EVERYTHING IS FILLED FOR THE MEMORY GAME

    private void CheckBox() {
		if  (gameMode == 2) {
			if (box1Code > 0 && box2Code > 0) {
				allFilled = true;
                MatchCode();
            } else {
                playOnce = false;
                allFilled = false;
			}
		}
    }

    //CHECKS IF EVERYTHING IS FILLED AFTER PRESSING THE BUTTON

    public void CheckAwnser() {
        if (gameMode == 3) {
            if (box1Code > 0 && box2Code > 0 && box3Code > 0)
            {
                allFilled = true;
                MatchCode();
            }
            else
            {
                playOnce = false;
                allFilled = false;
            }
        }else if (gameMode == 4)
        {
            if (box1Code > 0 && box2Code > 0 && box3Code > 0 && box4Code > 0)
            {
                allFilled = true;
                MatchCode();
            }
            else
            {
                playOnce = false;
                allFilled = false;
            }
        }
    }

    //MATCHES THE CODE 
    private void MatchCode() {
        if (allFilled == true && boxCodeCombination == correctCode)
        {
            mouseClick = false;
            CorrectCode();
        }
        else if(playOnce == false)
        {
            StartCoroutine(WrongSound());
        }
    }

    //PLAYS THE WRONG SOUND ONCE
    IEnumerator WrongSound()
    {
        audio.Stop();
        audio.PlayOneShot(wrongSound);
        wrongAwnser = true;
        playOnce = true;
        yield return new WaitForSeconds(0);
    }

    //CHECKS THE GAMEMODE AND PLAYS THE CORRECT SOUND

    private void CorrectCode() {
        if (gameMode == 2)
        {
            if (playOnce == false)
            {
                StartCoroutine(SwitchScene());
            }
            playOnce = true;
        }
        else if (playOnce == false)
        {
            if (gameMode == 3)
            {
                if (playOnce == false)
                {
                    audio.Stop();
                    audio.PlayOneShot(correctSound1);

                    StartCoroutine(SwitchScene());
                }
                playOnce = true;
            }
            else if (gameMode == 4)
            {
                if (playOnce == false)
                { 
                    audio.Stop();
                    audio.PlayOneShot(correctSound2);

                    StartCoroutine(SwitchScene());
                }
                playOnce = true;
            }
        }
    }

    //PLAYS THE LAST SOUND AND SWITCHES SCENE
    IEnumerator SwitchScene()
    {
        if (gameMode == 3 || gameMode == 4)
        {
            yield return new WaitForSeconds(timeToWait);
            audio.Stop();
            audio.PlayOneShot(correctSound);
        }
        else {
            audio.Stop();
            audio.PlayOneShot(correctSound);
        }

        yield return new WaitForSeconds(timeToWait);
        Application.LoadLevel(nextLevelCode);
    }


    //MOUSECLICK BOOL TO KEEP PLAYER FROM DRAGGING AFTER THE GAME IS DONE
     
    public bool MouseClick
    {
        get
        {
            return mouseClick;
        }
    }

    public bool WrongAwnser
    {
        get
        {
            return wrongAwnser;
        }
    }

}
