using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ContinueButton : MonoBehaviour {

	//This needs to be attached to the UI Buttons Manager so when it's OnClick is active it will load the next scene.

	public void ContinueGame() {
        
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
    public void loadFirstScene()
    {
        SceneManager.LoadScene("Scene01-F", LoadSceneMode.Single);
    }
}
