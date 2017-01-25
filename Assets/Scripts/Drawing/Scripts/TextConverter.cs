using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextConverter : MonoBehaviour {
	[SerializeField]private InputField _inputText;
	[SerializeField]private Text _outputText;

	private void Update() {
		_outputText.text = _inputText.text;
	}
}
