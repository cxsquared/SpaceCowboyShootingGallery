using UnityEngine;
using System.Collections;

public class destroyRays : MonoBehaviour {

	public GameObject bigDonut;
	public GameObject rayContainer;
	private Vector3 be450pls = new Vector3(150, 150, 150);

	void OnTriggerEnter(Collider other) {
		if (other.name != "boundary") {
						Destroy (other.gameObject);
						bigDonut = (GameObject)Instantiate (bigDonut);
						bigDonut.name = "donut";
						bigDonut.transform.parent = rayContainer.transform;
						bigDonut.transform.localPosition = new Vector3 (0, -12, 0);
						bigDonut.transform.localScale = be450pls;
				}
	}
}
