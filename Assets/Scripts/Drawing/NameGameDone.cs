using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGameDone : MonoBehaviour
{

    [SerializeField]
    private AudioClip completeSound;

    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private float timeToWait;

    private bool pressOnce = true;

    public string levelToLoad = "NameGameToOddOneOutGame";

    public void NewScene()
    {
        if (pressOnce)
        {
            StartCoroutine(SwitchScene());
        }
    }

    IEnumerator SwitchScene()
    {
        audio.Stop();
        audio.PlayOneShot(completeSound);
        pressOnce = false;
        yield return new WaitForSeconds(timeToWait);
        Application.LoadLevel(levelToLoad);
    }

}