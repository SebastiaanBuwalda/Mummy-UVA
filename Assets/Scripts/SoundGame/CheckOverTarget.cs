using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOverTarget : MonoBehaviour {

    private Vector2 boxPosition;

    private DragObjects tileScript;
    private bool mouseUp = false;

    private bool lockIn = false;

    private GameObject tile;

    private int tileNumber;

    private bool alreadyTiled = false;

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
    }

    private void LockInPlace() {
        if (!mouseUp)
        {
            tile.transform.position = boxPosition;
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
