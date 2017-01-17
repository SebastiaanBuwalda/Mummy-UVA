using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class DragObjects : MonoBehaviour {

    private Vector2 mousePosition2D;

    private Vector2 originalPosition2D;

    private bool snapToMouse = false;

    private bool aboveTarget = false;

    [SerializeField]
    private int tileNumber;

    public bool AboveTarget;

    void Start()
    {
        originalPosition2D = this.transform.position;
    }

    void OnMouseDown()
    {
        snapToMouse = true;
    }

    void OnMouseUp()
    {
        snapToMouse = false;

        aboveTarget = AboveTarget;

        if (aboveTarget)
        {
            Debug.Log("target locked");
        }
        else {
            this.transform.position = originalPosition2D;
        }
    }

    void Update()
    {
        if (snapToMouse)
        {
            mousePosition2D = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            this.transform.position = mousePosition2D;
        }
    }

    public bool SnapToMouse
    {
        get
        {
            return snapToMouse;
        }
    }

    public int TileNumber
    {
        get
        {
            return tileNumber;
        }
    }
}
