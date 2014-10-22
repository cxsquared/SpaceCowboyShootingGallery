using UnityEngine;
using System.Collections;

public class DiscManager : MonoBehaviour {

	public static int score = 0;

	public static int numOfDiscs = 0;

	public static int shipsHit = 0;

	public static bool started = false;

	public static Object alien = Resources.Load("Prefabs/Alien");
	
	public static float getAccuracy() {
		return ((float) shipsHit / (float) numOfDiscs) * 100;
	}

	public static void alienHit(int s){
		score += s;
		shipsHit++;
		//Debug.Log ("Alien killed");
	}

	void Awake() {
		DontDestroyOnLoad (this);
	}

	void FixedUpdate() {
		if (Random.value > 0.15) {
		}
	}

}
