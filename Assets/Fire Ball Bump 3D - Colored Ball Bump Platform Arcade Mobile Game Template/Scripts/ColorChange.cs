using UnityEngine;
using System.Collections;

//This script can be applied to any Gameobject with renderer and it will change the color randomly.

public class ColorChange : MonoBehaviour {

	float timeLeft;
	Color targetColor;
	
	
	void Update() {
		
		 	if (timeLeft <= Time.deltaTime)
	 	{
			GetComponent<Renderer>().material.color = targetColor;
			targetColor = new Color(Random.value, Random.value, Random.value);
			timeLeft = 1.0f;
		} else {
												
			GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, targetColor, Time.deltaTime / timeLeft);
			timeLeft -= Time.deltaTime;
		}
	}
}

