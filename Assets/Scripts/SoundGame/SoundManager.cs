using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    [SerializeField]
    private AudioClip tileSound;

    private AudioSource audio;

    // Use this for initialization
    void Start () {
        audio = gameObject.GetComponent<AudioSource>();
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
