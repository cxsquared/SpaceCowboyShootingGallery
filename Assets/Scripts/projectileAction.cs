using UnityEngine;
using System.Collections;

public class projectileAction : MonoBehaviour {

	public int rotationSpeed;
	public int projectileSpeed;


	// Update is called once per frame
	void Update () {
				transform.Translate (Vector3.right * Time.deltaTime * projectileSpeed);

		//Debug.Log ("Position = " + transform.position);

				if (transform.position.x > 500) {
		
						Destroy (this.gameObject);
						//transform.Rotate (Vector3.up * Time.deltaTime * rotationSpeed);
						//transform.Rotate (Vector3.forward * Time.deltaTime * rotationSpeed);
						//transform.Rotate (Vector3.left * Time.deltaTime * rotationSpeed);
				}
		}
}
