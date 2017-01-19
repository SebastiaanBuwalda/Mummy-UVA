using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievments : MonoBehaviour {

    [SerializeField]
    private int score;

    [SerializeField]
    public Color gold, silver, bronze;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CheckScore()
    {
        if (score <= 49)
        {
            
        }

        else if (score > 49 && score <=74)
        {

        }

        else if (score >= 75)
        {

        }
    }
}
