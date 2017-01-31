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
    }
}
