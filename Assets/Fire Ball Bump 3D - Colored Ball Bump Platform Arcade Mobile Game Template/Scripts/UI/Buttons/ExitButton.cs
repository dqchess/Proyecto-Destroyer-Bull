using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class ExitButton : MonoBehaviour {

	//This needs to be attached to the UI Buttons Manager so when it's OnClick is active it will exit the game.

	public void ExitGame() {
		Application.Quit(); //Exit the game
	}
}
