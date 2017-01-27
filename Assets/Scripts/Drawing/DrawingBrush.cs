using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingBrush : MonoBehaviour {


	[SerializeField]
	private int minX;

	[SerializeField]
	private int maxX;

	[SerializeField]
	private int minY;

	[SerializeField]
	private int maxY;


	[SerializeField]
	private List<GameObject> DrawingSaver = new List<GameObject>();

	[SerializeField]
	private GameObject myBrush;

	void FixedUpdate () 
	{
		if (Input.GetMouseButton (0)) {
			var v3 = Input.mousePosition;
			v3.z = 10.0F;
			v3 = Camera.main.ScreenToWorldPoint(v3);
			if (v3.x > minX && v3.x < maxX && v3.y > minY && v3.y < maxY) {
				GameObject brushie = Instantiate (myBrush, v3, Quaternion.identity);
				DrawingSaver.Add (brushie);
			}
		}
	}

	public void SaveDrawing()
	{
		foreach (GameObject dot in DrawingSaver) 
		{
			DrawingSaverScript.DrawingList.Add (dot);
		}
	}
}
