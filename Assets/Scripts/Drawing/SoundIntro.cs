using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundIntro : MonoBehaviour
{
    [SerializeField]
    private AudioClip introSound;

    [SerializeField]
    private AudioClip introSound2;

    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private float timeToWait;

    void Start()
    {
        audio.PlayOneShot(introSound);
        StartCoroutine(SwitchScene());
    }

    //PLAYS second intro sound
    IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(timeToWait);
        audio.Stop();
        audio.PlayOneShot(introSound2);
    }
}
