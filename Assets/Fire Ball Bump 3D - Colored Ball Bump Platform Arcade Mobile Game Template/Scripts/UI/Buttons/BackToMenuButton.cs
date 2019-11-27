using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BackToMenuButton : MonoBehaviour {

	//This needs to be attached to the UI Buttons Manager so when it's OnClick is active it will take you back to scene 0. (Main Menu)

	public void BackToMenuGame() {
		SceneManager.LoadScene(0); // loads current scene 0 which is main menu.
	}
}
