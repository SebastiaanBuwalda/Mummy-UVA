using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegularOne : MonoBehaviour {

    [SerializeField]
    private Sprite _oddOneOutSprite;

    [SerializeField]
    private AudioClip _HelaasDitIs;

    [SerializeField]
    private AudioClip _goedGedaan;

    [SerializeField]
    private AudioClip DeRichtingWaarin;

    [SerializeField]
    private AudioClip GebruikJeVinger;

    private bool clicked = false;

    public void Click()
    {
        SoundSystem.playAudio(_HelaasDitIs);
    }

    private void OnEnable() {
        OddOne.Change += ChangeSprite;
    }
    private void OnDisable() {
        OddOne.Change -= ChangeSprite;
    }

    private void OnDestroy()
    {
        if (GetComponent<OddOne>() == null) return;

        GetComponent<Image>().sprite = _oddOneOutSprite;
        GetComponent<OddOne>().GoedGedaan = _goedGedaan;
        GetComponent<OddOne>().DeRichtingWaarin = DeRichtingWaarin;
    }

    private void ChangeSprite()
    {
        int r = Random.Range(1, 18);
        GetComponent<Image>().sprite = (Sprite)Resources.Load("Ex2/" + r.ToString(), typeof(Sprite));
        SoundSystem.playAudio(GebruikJeVinger);
    }
}