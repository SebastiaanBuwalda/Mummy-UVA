using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Drawing : MonoBehaviour {
	private Pencil _pencil = new Pencil();
	private Renderer _boardRenderer;
	private Texture2D _board;
	private int _width;
	private int _height;

	private void Start() {
		_width = Screen.width;
		_height = Screen.height;
		_board = CreateDrawingBoard ();
		_pencil.SetColor (Color.white);


	}

	private Texture2D CreateDrawingBoard() {
		Texture2D board = new Texture2D (_width, _height);
		Color[] c = board.GetPixels();

		for (int i = 0; i < c.Length; i++) {
			c[i] = new Color(0,0,0);
		}	

		board.SetPixels (c);
		board.Apply ();
		return board;
	}

	private void OnGUI() {
		if (Event.current.type.Equals(EventType.Repaint))
			Graphics.DrawTexture (new Rect (0, 0, _width, _height), _board);
	}

	private void Update() {
		if (Input.GetMouseButton (0)) {
			_pencil.DrawPixel (_board);
		}
	}
}
