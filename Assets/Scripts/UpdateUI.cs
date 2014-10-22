using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateUI : MonoBehaviour {

	public Text uiText;
	
	// Update is called once per frame
	void Update () {
		uiText.text = "Score: " + DiscManager.score + " Accuracy " + DiscManager.getAccuracy () + "%";
	}
}
