using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	//This script can be added to a button with box collider so when you click it then the game will start and load scene 1.

	void OnMouseDown() {
		//Application.LoadLevel(Application.loadedLevel+1);
		SceneManager.LoadScene(+1);
		}
}
