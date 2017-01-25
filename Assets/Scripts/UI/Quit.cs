using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {

    [SerializeField]
    private int timeToWait = 3;

  
    // Use this for initialization
    void Start()
    {
        StartCoroutine(QuitGame());
    }

    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(timeToWait);
        Application.Quit();


    }
}
