using UnityEngine;
using System.Collections;

public class FixRotation : MonoBehaviour {

	public GameObject player;
	private Vector3 offset;
	public GameObject[] goals;
	private bool[] goalsCompleted;
	public bool enabled = true;
	public bool mouseCamera = false;
	public int currentCheck = 0;

	private bool mouseClick = false;

	public float cameraRotateSpeed = 5.0f;

	void Start()
	{
		offset = transform.position;

		goalsCompleted = new bool[goals.Length];
	}
	
	void LateUpdate()
	{
		if (enabled) {
						transform.position = player.transform.position + offset;
				}

		if (mouseCamera) {
			if (Input.GetMouseButtonDown(0)) {
				mouseClick = true;
			}
			if (Input.GetMouseButtonUp(0)) {
				mouseClick = false;
			}
			if (mouseClick) {
				//this.transform.rotation = RotatePointAroundPivot(this.transform.position, player.transform.position, Input.GetAxis("Mouse X") * Vector3.Angle(this.transform.position, player.transform.position));
				transform.RotateAround( player.transform.position, Vector3.one, Input.GetAxis( "Mouse X" ) * cameraRotateSpeed );
			}
		}

	}

	public void lookAtGoal() {

//		//transform.LookAt (player.transform);
//		//transform.Translate (Vector3.right * Time.deltaTime);
		int checkpoint = 0;
		for (checkpoint = 0; checkpoint < goals.Length; checkpoint++) {
			if (goalsCompleted[checkpoint] == false){
				currentCheck = checkpoint;
				break;
			}
		}
		player.transform.LookAt (goals [checkpoint].transform);

		float angle = Vector3.Angle (player.transform.position, goals [checkpoint].transform.position);
		Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.up);

		transform.position = player.transform.position;

		transform.position = rotation * transform.position;

		transform.position = new Vector3(transform.position.x * player.transform.forward.x, transform.position.y * player.transform.forward.y, transform.position.z * player.transform.forward.z - 10.3f);

		Quaternion lookAt = Quaternion.LookRotation (goals [checkpoint].transform.position - transform.position);

		transform.rotation = Quaternion.Lerp (transform.rotation, lookAt, 1.0f);

//		Debug.Log ("Checkpoint = " + checkpoint);
//		transform.LookAt (goals[checkpoint].transform);
//		Debug.Log ("Player position = " + player.transform.position);
//		Debug.Log ("Camera positon = " + this.transform.position);
//
//
//		float anglePlayer = Vector3.Angle(player.transform.position, goals[checkpoint].transform.position);
//		float playerCamera = Vector3.Angle (player.transform.position, this.transform.position);
//		transform.RotateAround (player.transform.position, Vector3.up, anglePlayer + playerCamera);
//		Vector3 newPos = this.transform.position;
//		newPos.Scale (this.transform.forward);
//		player.transform.position = newPos;
		player.transform.rotation = new Quaternion (0.0f, this.transform.rotation.y, 0.0f, this.transform.rotation.w);
	}

	public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion angle) {
		return angle * (point - pivot) + point;
	}

	public void PlayerEnteredCheckpoint(string goalName) {
		if (goalName == "checkpoint") {
						goalsCompleted [0] = true;
				} else if (goalName == "Goal") {
			goalsCompleted [1] = true;
				}
	}
}
