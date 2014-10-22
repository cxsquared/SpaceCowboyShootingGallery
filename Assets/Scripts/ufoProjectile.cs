using UnityEngine;
using System.Collections;

public class ufoProjectile : MonoBehaviour {


	public GameObject projectile;
	private float myTimer = 5.0f;

	// Update is called once per frame
	void Update () {


		if (myTimer > 0) {
			myTimer -= Time.deltaTime;
		}
		if (myTimer <= 0) {
			Instantiate (projectile);
			myTimer = 5.0f;

		}
	}
}
