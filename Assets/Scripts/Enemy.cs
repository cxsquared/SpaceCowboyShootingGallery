using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject ufo;

	public int health = 3;

	void Update(){
		if (health <= 0) {
			Destroy(ufo.gameObject);
		}
	}

	void OnCollisionEnter(Collision collision){
		Debug.Log ("Hit by something");
		if (collision.gameObject.tag == "Player") {
			health--;
			Debug.Log("Player hit me");
		}
	}
}
