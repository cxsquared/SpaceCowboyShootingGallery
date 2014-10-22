using UnityEngine;
using System.Collections;

public class scaleRays : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float setScale = 1f;
		transform.localScale -= new Vector3(setScale, setScale, setScale);
	}
}
