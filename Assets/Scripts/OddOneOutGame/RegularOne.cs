using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegularOne : MonoBehaviour {

    [SerializeField]
    private Sprite _oddOneOutSprite;

    public void Click()
    {
        Debug.Log("Sorry, that is wrong. Try again");
    }

    private void OnDestroy()
    {
        GetComponent<Image>().sprite = _oddOneOutSprite;
    }
}