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
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

        if (gameMode == 3)
        {
            box1Code = box1.gameObject.GetComponent<CheckOverTarget>().TileNumber;
            box2Code = box2.gameObject.GetComponent<CheckOverTarget>().TileNumber;
            box3Code = box3.gameObject.GetComponent<CheckOverTarget>().TileNumber;
            box4Code = box4.gameObject.GetComponent<CheckOverTarget>().TileNumber;

            correctCode = "3456";

            boxCodeCombination = box1Code.ToString() + box2Code.ToString() + box3Code.ToString() + box4Code.ToString();
        }
        else if (gameMode == 2)
        {
            box1Code = box1.gameObject.GetComponent<CheckOverTarget>().TileNumber;
            box2Code = box2.gameObject.GetComponent<CheckOverTarget>().TileNumber;

            correctCode = "52";

            boxCodeCombination = box1Code.ToString() + box2Code.ToString();
        }
        


        CheckBox();
        MatchCode();
    }

    private void CheckBox() {
		if (gameMode == 3) {
			if (box1Code > 0 && box2Code > 0 && box3Code > 0 && box4Code > 0) {
				allFilled = true;
				Debug.Log (boxCodeCombination);
			} else {
				allFilled = false;
			}
		}
		else if  (gameMode == 2) {
			if (box1Code > 0 && box2Code > 0) {
				allFilled = true;
				Debug.Log (boxCodeCombination);
			} else {
				allFilled = false;
			}
		}
    }

    private void MatchCode() {
        if (allFilled == true && boxCodeCombination == correctCode)
        {
            Debug.Log("you got it");
			Application.LoadLevel (nextLevelCode);

        }


    }
}
