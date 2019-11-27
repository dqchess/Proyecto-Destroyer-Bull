using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGameButton : MonoBehaviour {

	//This is the script to be applied with a box collider 2D button so you can continue from your saved progress.

	private int sceneToContinue;
	void OnMouseDown() {
		sceneToContinue = PlayerPrefs.GetInt("SavedScene");

		if (sceneToContinue != 0)
			SceneManager.LoadScene(sceneToContinue);
		else
			return;
	}
}
/*
	void Awake()
	{
		SceneManager.sceneLoaded += SceneManager_sceneLoaded;
		SceneManager.LoadScene("Game");
	}

	private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
		Debug.Log(arg0.name);
	}
}
*/