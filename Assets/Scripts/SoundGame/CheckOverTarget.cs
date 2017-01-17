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

    void update()
    {
        if (lockIn & mouseUp)
        {
            Debug.Log("help");
            tile.transform.position = boxPosition;
            tileScript.AboveTarget = true;
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

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Tile")
        {
            tileScript = other.gameObject.GetComponent<DragObjects>();
            tile = other.gameObject;
            lockIn = true;
            Debug.Log(lockIn);
        }
        else {
            lockIn = false;                
        }
    }
}
