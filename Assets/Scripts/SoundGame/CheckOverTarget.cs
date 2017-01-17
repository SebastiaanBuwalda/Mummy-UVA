using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOverTarget : MonoBehaviour {

    private Vector2 boxPosition;

    private DragObjects tileScript;
    private bool mouseUp = false;

    private bool lockIn = false;

    private GameObject tile;

    // Use this for initialization
    void Start() {
        boxPosition = this.transform.position;
    }

    void Update()
    {
        if (lockIn)
        {
            Debug.Log("help");
            tileScript = tile.gameObject.GetComponent<DragObjects>();

            tile.transform.position = boxPosition;
            tileScript.AboveTarget = true;
            lockIn = false;
        }else if(tileScript != null)
        {
            tileScript.AboveTarget = false;
        }

    }

    void OnMouseDown()
    {
        mouseUp = false;
    }

    void OnMouseUp()
    {
        mouseUp = true;
    }

    void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.tag == "Tile")
        {
            tile = other.gameObject;
            lockIn = true;
            Debug.Log(lockIn);
        }
        else {
            lockIn = false;
        }
    }
}
