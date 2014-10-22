using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public bool hit = false;

	public FixRotation fr;

	//To detect collision entering   
	public void OnTriggerEnter (Collider target)
	{
		if (target.tag == "Player") {
			fr.SendMessage("PlayerEnteredCheckpoint", gameObject.name);
		}
	}

	void Start() {
		//Debug.Log (this.name);
	}
}
