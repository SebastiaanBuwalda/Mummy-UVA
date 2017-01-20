using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [SerializeField]
    private AudioClip tileSound;

    [SerializeField]
    private AudioSource audio;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown() {
        playSound();
    }

    private void playSound()
    {
        audio.Stop();
        audio.PlayOneShot(tileSound);
    }
}
