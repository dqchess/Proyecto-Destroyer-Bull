using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class StartGameButton : MonoBehaviour {

	//This needs to be attached to the UI Buttons Manager so when it's OnClick is active it will load scene 1.

	public void StartGame() {
		SceneManager.LoadScene(1); //Loads the current scene
	}
}
