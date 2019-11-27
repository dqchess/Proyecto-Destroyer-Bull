using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RestartButton : MonoBehaviour {

	//This needs to be attached to the UI Buttons Manager so when it's OnClick is active it will restart the game.

	public void RestartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Restart the game
	}

}