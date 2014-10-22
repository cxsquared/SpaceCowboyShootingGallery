using UnityEngine;
using System.Collections;
using Leap;

public class Disc : MonoBehaviour {

	private Controller leap_controller;

	public int velocityPad = 5;

	public ThrowState state = ThrowState.OPEN;

	public bool throwing = false;

	private Vector3 throwStart;
	private Vector3 throwEnd;

	private Vector3 velocity;
	private Vector3 lastPositon;
	private Vector3 startPosition;

	private float offsetX;
	private float offsetY;

	public FixRotation cameraRotation;

	public GameObject otherDisc;

	public bool collided = false;

	public float friction = 0.1f;

	public enum ThrowState {
		OPEN,
		CLOSED,
		THROWING
	}

	public Disc(){
	}

	public Disc(GameObject otherDisc){
		this.otherDisc = otherDisc;
	}

	// Use this for initialization
	void Start () {
		leap_controller = new Controller();

		if (leap_controller == null) {
			Debug.LogWarning(
				"Cannot connect to controller. Make sure you have Leap Motion v2.0+ installed");
		}
		lastPositon = transform.position;

		offsetX = 0.0f;
		offsetY = 0.0f;

		//Debug.Log ("Player start positon = " + objDisc.transform.position);
		//Debug.Log ("Camera start position = " + Camera.main.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (DiscManager.started) {
						if (leap_controller == null)
								return;
		
						Frame frame = leap_controller.Frame ();

						if (frame.Hands.Count > 0) {
								if (frame.Hands [0].GrabStrength >= 1.0 && !throwing) {
										state = ThrowState.CLOSED;
								} else if (state == ThrowState.CLOSED) {
										state = ThrowState.THROWING;
								}

								updateDisc (frame.Hands);

						}

						if (throwing && !collided) {
								Rotate ();
						}

						//Debug.Log ("State = " + state);

						//Debug.Log("Disc x = " + transform.position.x);
						//Debug.Log("Disc y = " + transform.position.y);
						//Debug.Log("Disc z = " + transform.position.z);
				} else {
			this.rigidbody.isKinematic = true;
				}
	}

	private void updateDisc(HandList hands) {

		float newX = (hands [0].PalmPosition.x / 15) + offsetX;

		float newY = (hands [0].PalmPosition.y / 15) + offsetY;

		if (state == ThrowState.OPEN) {
			rigidbody.Sleep();
			rigidbody.isKinematic = true;
			transform.position = new Vector3 (newX, newY, transform.position.z);
		} else if (state == ThrowState.CLOSED) {
			rigidbody.Sleep();
			velocity = new Vector3 (hands [0].PalmVelocity.x, hands [0].PalmVelocity.y, hands [0].PalmVelocity.z);
		} else if (state == ThrowState.THROWING) {
			if(!throwing){
				velocity.x = velocity.x * 2;
				velocity.y = Mathf.Abs(velocity.y);
				velocity.z = Mathf.Abs(velocity.z * -3);
				throwDisc(velocity);
			} else if (throwing) {
				if (!collided) {
					//Debug.Log("Still throwing");
					lastPositon = transform.position;
				} else if (collided) {
					offsetX = hands[0].PalmPosition.x;
					offsetY = hands[0].PalmPosition.y;
					throwing = false;
					if(cameraRotation.enabled){
						cameraRotation.lookAtGoal();
						Debug.Log("Camera called");
					}
					//Debug.Log("Not Throwing");
					state = ThrowState.OPEN;
				}
			}
		}

		//Debug.Log ("State = " + state);
	}

	private void throwDisc(Vector3 velocity){
			startPosition = transform.position;
			collided = false;
			rigidbody.isKinematic = false;
			rigidbody.WakeUp();
			rigidbody.AddForce (velocity.x, velocity.y, velocity.z, ForceMode.Force);
			throwing = true;
	}

	void Rotate() {
		rigidbody.transform.Rotate (Vector3.up, 2000f * Time.deltaTime);
	}

	void OnCollisionEnter(Collision collision){
		// Debug.Log ("Collided");
		collided = true;
			if (GameObject.FindGameObjectsWithTag("Player").Length <= 1) {
				GameObject d = (GameObject)Instantiate (otherDisc, new Vector3 (-0.034f, 3.011f, 0), new Quaternion ());
				d.GetComponent<Disc> ().otherDisc = this.otherDisc;
			}
		DiscManager.numOfDiscs++;
		//Debug.Log ("Number of discs = " + DiscManager.numOfDiscs);
		Destroy (this.gameObject);
	}
}
