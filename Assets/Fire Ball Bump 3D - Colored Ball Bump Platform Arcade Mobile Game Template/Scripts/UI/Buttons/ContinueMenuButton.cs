using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueMenuButton : MonoBehaviour {

	//This needs to be attached to the UI Buttons Manager so when it's OnClick is active it will take you back to scene you were last. (ONLY IN MENU)
	private int sceneToContinue;

	public void ContinueMenuGame() {
		sceneToContinue = PlayerPrefs.GetInt("SavedScene");

		if (sceneToContinue != 0)
			SceneManager.LoadScene(sceneToContinue);
		else
			return;
	}
}
