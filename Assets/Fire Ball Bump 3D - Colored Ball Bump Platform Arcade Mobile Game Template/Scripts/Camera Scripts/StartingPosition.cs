using UnityEngine;
using System.Collections;

public class StartingPosition : MonoBehaviour {

	//This script will make the game freeze at start and will play when you click on the screen only.

	public AudioClip StartSound;

	void Start () {
		isStartButtonPressed = false;
		//Time.timeScale = 0.0f;
	}

	private bool isStartButtonPressed;

	void OnGUI()
	{
			if (!isStartButtonPressed)
			{
			if(Input.anyKeyDown)
			{
				//BallControll.DidGameStart = true;
				//CameraMovement.DidGameStart = true;
				Destroy (GameObject.FindWithTag("Destroy"));
				GetComponent<AudioSource>().PlayOneShot(StartSound, 7.7F);
				Time.timeScale = 1.0f;
				isStartButtonPressed = true;
			}
		}
	}
}
