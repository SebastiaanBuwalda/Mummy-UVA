using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievments : MonoBehaviour {

    [SerializeField]
    private int score;

    [SerializeField]
    private Color gold = new Color(255f, 216f, 0f);

    [SerializeField]
    private Color silver = new Color(238f, 238f, 238f);

    [SerializeField]
    private Color bronze = new Color(255f, 174f, 0f);

    [SerializeField]
    private Image medal;

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
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();  //Get the renderer via GetComponent or have it cached previously
            renderer.color = bronze; // Set to opaque black
        }

        else if (score >= 50 && score <=74)
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();  //Get the renderer via GetComponent or have it cached previously
            renderer.color = silver; // Set to opaque black
        }

        else if (score >= 75)
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();  //Get the renderer via GetComponent or have it cached previously
            renderer.color = gold; // Set to opaque black
        }
    }
}
