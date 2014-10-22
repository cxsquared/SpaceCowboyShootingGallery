using UnityEngine;
using System.Collections;

public class ufoMove : MonoBehaviour {

	public GameObject ufo;
	public GameObject bullet;
	private int speed = 1;
	private float startDirection;

	private int health = 3;
	// Use this for initialization
	void OnTriggerEnter (Collider wall){
		speed *= -1;
		if (wall.gameObject.tag == "Player") {
			health--;
			Debug.Log("Player hit me. My health is " + health);
				}

	}

	void Start () {
			startDirection = (Random.value);
			if (startDirection > 0.5) {
				speed *= -1;
			}
		}
	// Update is called once per frame
	void Update () {

		transform.Translate (Vector3.right * Time.deltaTime * 20 * speed);

		if (Input.GetKeyDown("space")) {
			health--;
			Debug.Log("Player hit me. My health is " + health);
		}


		bullet.transform.position = ufo.transform.position;

		if (health <= 0) {
			Destroy(this.gameObject);
				}

	}

}

