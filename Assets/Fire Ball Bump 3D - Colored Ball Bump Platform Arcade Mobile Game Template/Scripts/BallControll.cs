using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControll : MonoBehaviour {

	[SerializeField] private float ThrustSpeed = 50f; //The speed of the ball thrust
	[SerializeField] private Rigidbody rigidbodyBall; //Get the rigidbody of the ball.
	[SerializeField] private float minCamDistance = 3f; //Get the min camera distance on how much the player ball can move from camera.
	[SerializeField] private float maxCamDistance = 5f; //Get the max camera distance on how much the player ball can move from camera.
   
	public float AutoMovementSpeed = 2f; //The automatic movement speed of the player ball when the player is not touching it. This should be the same as the one in the camera.
	private Vector2 lastMousePos; //Get last mouse position.
	bool wingameGUI = false; //The GUI that will be displayed when game is won.
	bool gameoverGUI = false; //The GUI that will be displayed when game is lost.
	//public Texture EndGameFullScreenGUI; //The GUI that will display a big texture on the full screen when the game end, both win or lost.
	//public GUIStyle GameOverGUI = new GUIStyle(); //This is the GUI style of the Game Over text that will be displayed.
	//public GUIStyle WinGameGUI = new GUIStyle(); //This is the GUI style of the Win Game text that will be displayed. 
	//public Texture ExitGameButtonHUD; //The exit HUD button that will display when the game ends.
	//public Texture RetryGameButtonHUD; //The retry HUD button that will display when the game ends.
	//public Texture NextGameButtonHUD; //The next level HUD button that will display when the game ends.
	public AudioClip GameOverSound; //The sound that will play when the player dies and game is lost.
	public AudioClip WinGameSound; //The sound that will play when the player completes the level.

	public GameObject completeGameOverUI;
	public GameObject completeGameWonUI;

	private int currentSceneIndex; //This will get your current scene.

	void Start () {
		completeGameOverUI.gameObject.SetActive(false);
		completeGameWonUI.gameObject.SetActive(false);
	}

	void Update () {

        
        Vector2 deltaPos = Vector2.zero;
       
		if (Input.GetMouseButton(0)) {          
            Vector2 currentMousePos = Input.mousePosition; 
           
			if (lastMousePos == Vector2.zero)
				lastMousePos = currentMousePos;
           
			deltaPos = currentMousePos - lastMousePos;
			lastMousePos = currentMousePos;

			Vector3 force = new Vector3(deltaPos.x, 0, deltaPos.y) * ThrustSpeed;
			rigidbodyBall.AddForce(force);
           transform.rotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
            /*Quaternion desiredRotation = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime *0.5f); */
        } else {
			lastMousePos = Vector2.zero;
		}
	}

    
	 void OnCollisionEnter (Collision col) {
		/*if (col.gameObject.tag == "KillPlayer") {
			gameoverGUI = true;
			this.gameObject.GetComponentInChildren<Renderer> ().enabled = false;
			this.gameObject.GetComponentInChildren<Collider> ().enabled = false;
			foreach (Renderer r in GetComponentsInChildren<Renderer>())
			r.enabled = false;
			Destroy (GameObject.FindWithTag("BackgroundMusic"));
			GetComponent<AudioSource>().PlayOneShot(GameOverSound, 2.7F);
			Die();
		}*/

		if (col.gameObject.tag == "WinGame") {
			wingameGUI = true; 
			this.gameObject.GetComponentInChildren<Renderer> ().enabled = false;
			this.gameObject.GetComponentInChildren<Collider> ().enabled = false;
			foreach (Renderer r in GetComponentsInChildren<Renderer>())
			r.enabled = false;
			Destroy (GameObject.FindWithTag("BackgroundMusic"));
			GetComponent<AudioSource>().PlayOneShot(WinGameSound, 2.7F);
			Win();
		}
	}

	private void FixedUpdate()
	{
		rigidbodyBall.MovePosition(transform.position + Vector3.forward * AutoMovementSpeed * Time.fixedDeltaTime);
	}

	void LateUpdate () {

		Vector3 pos = transform.position;

		if (transform.position.z < Camera.main.transform.position.z + minCamDistance)
		{
			pos.z = Camera.main.transform.position.z + minCamDistance;
		}

		if (transform.position.z > Camera.main.transform.position.z + maxCamDistance)
		{
			pos.z = Camera.main.transform.position.z + maxCamDistance;
		}

		transform.position = pos;
	}

	void Die() {
		completeGameOverUI.gameObject.SetActive(true);
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
	}

	void Win() {
		completeGameWonUI.gameObject.SetActive(true);
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
	}
}

		
		

	//This has been disabled since we are using UI now.
/*
	void OnGUI() {
		if (gameoverGUI) {
			wingameGUI = false;
		
			GUI.DrawTexture(new Rect(((Screen.width / 3) - 868f), ((Screen.height / 5) - 741.5f), 5600, 2975), EndGameFullScreenGUI, ScaleMode.ScaleToFit, true, 0.0F);
			GUI.Label (new Rect(Screen.width / 2 - 48f, ((Screen.height / 2) - 34.5f), 40, -210), "GAME OVER", GameOverGUI);

			if ( GUI.Button(new Rect(Screen.width / 2 - (320f / 2), Screen.height / 2 - -150, 110, 110), ExitGameButtonHUD)) {
				currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
				PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
				SceneManager.LoadScene(0);
			}

			if ( GUI.Button(new Rect(Screen.width / 2 - (-100f / 2), Screen.height / 2 - -150, 110, 110), RetryGameButtonHUD)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

			}
		}

		if (wingameGUI) {
			gameoverGUI = false;

			GUI.DrawTexture(new Rect(((Screen.width / 3) - 868f), ((Screen.height / 5) - 741.5f), 5600, 2975), EndGameFullScreenGUI, ScaleMode.ScaleToFit, true, 0.0F); //Display the end game full screen.
			GUI.Label (new Rect(Screen.width / 2 - 48f, ((Screen.height / 2) - 34.5f), 40, -210), "LEVEL PASS", WinGameGUI);

			if ( GUI.Button(new Rect(Screen.width / 2 - (300f / 2), Screen.height / 2 - -130, 80, 80), ExitGameButtonHUD)) {
				currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
				PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
				SceneManager.LoadScene(0);

			}

			if ( GUI.Button(new Rect(Screen.width / 2 - (90f / 2), Screen.height / 2 - -130, 80, 80), RetryGameButtonHUD)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

			}

			if ( GUI.Button(new Rect(Screen.width / 2 - (-120f / 2), Screen.height / 2 - -130, 80, 80), NextGameButtonHUD)) {

				int currentLevel = Application.loadedLevel;
				Debug.Log(currentLevel); 
				if (currentLevel < Application.levelCount-1)
				{
					Application.LoadLevel(currentLevel + 1);
				} else {
					Application.LoadLevel(0);	
				}

			}
		}
	}
*/

