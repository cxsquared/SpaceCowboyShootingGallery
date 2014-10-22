using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour {

	public AudioClip clip;

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Player") {
						DiscManager.alienHit (5);
						audio.enabled = true;
						AudioSource.PlayClipAtPoint (clip, transform.position);
						Destroy (this.gameObject);
				}
		//Debug.Log ("Collision");
	}
}
