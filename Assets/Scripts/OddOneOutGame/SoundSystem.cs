using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour {

    [SerializeField]
    private AudioSource _source;

    public delegate void global(AudioClip clip);

    public static global playAudio;

    void OnEnable()
    {
        playAudio += PlayAudio;
    }

    private void PlayAudio(AudioClip clip)
    {
        _source.clip = clip;
        if(_source.isPlaying)
            _source.Stop();
        _source.Play();
    }
}