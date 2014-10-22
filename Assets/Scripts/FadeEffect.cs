using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeEffect : MonoBehaviour {

	public Text spaceText;
	public Text buttonText;
	public Button spaceButton;
	public float fadeSpeed = 5f;
	public bool clicked;
	public GameObject spaceCanvas;

	// Use this for initialization
	void Awake () {
		spaceText = spaceCanvas.GetComponentInChildren<Text> ();
		buttonText = spaceButton.GetComponentInChildren<Text> ();
		spaceButton.onClick.AddListener (() => {
						onClicked ();});
	}
	
	// Update is called once per frame
	void Update () {
		colorChange ();
	}

	public void onClicked(){
		clicked = true;
	}

	private void colorChange(){
		if (clicked) {
			spaceText.color = Color.Lerp(spaceText.color, Color.clear, fadeSpeed * Time.deltaTime);
			spaceButton.image.color = Color.Lerp(spaceButton.image.color, Color.clear, fadeSpeed * Time.deltaTime);
			buttonText.color = Color.Lerp(buttonText.color, Color.clear, fadeSpeed * Time.deltaTime);
			spaceButton.enabled = false;
			DiscManager.started = true;
		}
	}
}
