using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class DragObjects : MonoBehaviour {

    [SerializeField]
    private GameObject matcher;

    private CodeMatcher codeMatcher;
    private bool mouseClick;

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

    void Update()
    {
        codeMatcher = matcher.gameObject.GetComponent<CodeMatcher>();
        mouseClick = codeMatcher.MouseClick;

        if (snapToMouse)
        {
            mousePosition2D = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            this.transform.position = mousePosition2D;
        }
    }

    void OnMouseDown()
    {
        if (mouseClick)
        {
            snapToMouse = true;
        }
    }

    void OnMouseUp()
    {
        snapToMouse = false;

        if (AboveTarget)
        {

        }
        else {
            if (!AboveTarget)
            {
                this.transform.position = originalPosition2D;
            }
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
