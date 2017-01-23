using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pencil {

	private Color _color;

	public void SetColor(Color c) {
		_color = c;	
	}

	public void DrawPixel (Texture2D drawingBoard) {
		Vector2 mousePos = MousePos ();
		var arr = PixelsInRadius (mousePos, 5);
		for (int i = 0; i < arr.Count; i++) {
			drawingBoard.SetPixel ((int)arr [i].x, (int)arr [i].y, Color.white);	
		}

		drawingBoard.Apply ();
	}

	private List<Vector2> PixelsInRadius(Vector2 pos, int radius) {
		List<Vector2> positions = new List<Vector2>();
		for (int x = -radius; x < radius; x++) {
			if (!positions.Contains (new Vector2 (pos.x - x, pos.y))) {
				positions.Add (new Vector2 (pos.x - x, pos.y));
			}
			for (int y = -radius; y < radius; y++) {
				if (!positions.Contains (new Vector2 (pos.x, pos.y - y))) {
					positions.Add (new Vector2 (pos.x, pos.y - y));
				}

				if (!positions.Contains (new Vector2 (pos.x - x, pos.y - y))) {
					positions.Add (new Vector2 (pos.x - x, pos.y - y));
				}
			}
		}

		return positions;
	}

	private Vector2 MousePos() {
		Vector2 mousePos = Input.mousePosition;
		Vector2 roundMousePos = new Vector2(Mathf.Floor(mousePos.x + 0.5f), Mathf.Floor(mousePos.y + 0.5f));
		return roundMousePos;
	}
}
