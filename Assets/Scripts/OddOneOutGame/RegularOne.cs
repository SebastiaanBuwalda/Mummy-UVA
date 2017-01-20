using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegularOne : MonoBehaviour {

    [SerializeField]
    private Sprite _oddOneOutSprite;

    [SerializeField]
    private AudioSource _HelaasDitIs;

    [SerializeField]
    private AudioSource _goedGedaan;

    public void Click()
    {
        Debug.Log("Sorry, that is wrong. Try again");
        _HelaasDitIs.Play();
    }

    private void OnDestroy()
    {
        GetComponent<Image>().sprite = _oddOneOutSprite;
        GetComponent<OddOne>().goedGedaan = _goedGedaan;
    }
}