using UnityEngine;
using System.Collections;

public class levelLoader : MonoBehaviour {
	
	//start = 0; beginner = 1; intermediate= = 2; advanced = 3;
	void loadBeginnerLevel() 
	{
		Application.LoadLevel (1);
	}
	//start = 0; beginner = 1; intermediate= = 2; advanced = 3;
	void loadIntermediateLevel() 
	{
		Application.LoadLevel (2);
	}
	//start = 0; beginner = 1; intermediate= = 2; advanced = 3;
	void loadAdvancedLevel() 
	{
		Application.LoadLevel (3);
	}
}
