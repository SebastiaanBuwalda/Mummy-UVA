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

    private int box1Code;
    private int box2Code;
    private int box3Code;

    private string boxCodeCombination;

    private bool allFilled;

    private string correctCode = "345";
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        box1Code = box1.gameObject.GetComponent<CheckOverTarget>().TileNumber;
        box2Code = box2.gameObject.GetComponent<CheckOverTarget>().TileNumber;
        box3Code = box3.gameObject.GetComponent<CheckOverTarget>().TileNumber;

        boxCodeCombination = box1Code.ToString() + box2Code.ToString() + box3Code.ToString();

        CheckBox();
        MatchCode();
    }

    private void CheckBox() {
        if (box1Code > 0 && box2Code > 0 && box3Code > 0)
        {
            allFilled = true;
            Debug.Log(boxCodeCombination);
        }
        else {
            allFilled = false;
        }
    }

    private void MatchCode() {
        if (allFilled == true && boxCodeCombination == correctCode)
        {
            Debug.Log("you got it");
        }
    }
}
