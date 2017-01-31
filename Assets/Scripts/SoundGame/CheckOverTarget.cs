using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOverTarget : MonoBehaviour {

    private Vector3 boxPosition;

    private DragObjects tileScript;
    private bool mouseUp = false;

    private bool lockIn = false;

    private GameObject tile;

    private int tileNumber;

    private bool alreadyTiled = false;

    [SerializeField]
    private GameObject matcher;

    private CodeMatcher codeMatcher;
    private bool mouseClick;

    private bool wrongAwnser;

    [SerializeField]
    private bool gameModeS;

    // Use this for initialization
    void Start() {
        boxPosition = this.transform.position;
    }

    void Update()
    {
        Debug.Log(tile);
        if (lockIn)
        {
            tileScript = tile.gameObject.GetComponent<DragObjects>();
            mouseUp = tileScript.SnapToMouse;
            LockInPlace();
        }
        else if (tileScript != null)
        {
            alreadyTiled = false;
            tileScript.AboveTarget = false;
            tileNumber = 0;
            tile = null;
        }

        if (gameModeS)
        {
            codeMatcher = matcher.gameObject.GetComponent<CodeMatcher>();
            wrongAwnser = codeMatcher.WrongAwnser;

            if (wrongAwnser)
            {
                tileScript.AboveTarget = false;
            }
        }
    }

    private void LockInPlace() {
        if (!mouseUp)
        {
            tile.transform.position = new Vector3(boxPosition.x, boxPosition.y, boxPosition.z - 1);
            tileNumber = tileScript.TileNumber;
            tileScript.AboveTarget = true;
            alreadyTiled = true;
            mouseUp = true;
        }
    }

    void OnCollisionStay2D(Collision2D other) {
        if (alreadyTiled == false && tile == null)
        {
            tile = other.gameObject;
            lockIn = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
            lockIn = false;
    }

    public int TileNumber
    {
        get
        {
            return tileNumber;
        }
    }

}
