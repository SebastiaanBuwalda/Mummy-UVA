using UnityEngine;
using UnityEditor;
using System.Collections;

public class Drawing : MonoBehaviour {
	[SerializeField]private GameObject _lineHolder;
	[SerializeField]private GameObject _drawingBoard;
	private Renderer _renderer;

	private bool _drawingLine;
	private Vector2 _startPos;
	private Vector2 _endPos;

	private GameObject _currentLine;
	private LineRenderer _currentRenderer;

	private GameObject _drawing;


	private void Start() {
		_drawing = new GameObject ("Drawing Plane");
		_renderer = _drawingBoard.GetComponent<Renderer> ();
	}

	private void Update() {
		if (Input.GetMouseButtonDown (0)) {
			_startPos = MousePos ();
			_drawingLine = true;
			_currentLine = Instantiate (_lineHolder) as GameObject;

			_currentLine.transform.parent = _drawing.transform;

			_currentRenderer = _currentLine.GetComponent<LineRenderer> ();
		}

		if (Input.GetMouseButtonUp (0)) {
			_drawingLine = false;
		}

		if (_drawingLine) {
			CreateLine ();
		}
	}

	private void CreateLine() {
		Debug.Log (_renderer.bounds.extents.x);
		if (_startPos.x < _renderer.bounds.extents.x && _startPos.x > -_renderer.bounds.extents.x && 
		    _startPos.y < _renderer.bounds.extents.y && _startPos.y > -_renderer.bounds.extents.y) {
			_currentRenderer.SetPosition (0, _startPos);
		}

		if (MousePos ().x < _renderer.bounds.extents.x && MousePos ().x > -_renderer.bounds.extents.x &&
		    MousePos ().y < _renderer.bounds.extents.y && MousePos ().y > -_renderer.bounds.extents.y) {
			_currentRenderer.SetPosition (1, MousePos ());
		}

		_currentRenderer.SetVertexCount (2);
	}

	private Vector2 MousePos() {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
		return mousePos;
	}

	private void OnApplicationQuit() {
		PrefabUtility.CreatePrefab ("Assets/Prefabs/Drawing.prefab", _drawing);
	}
}
