using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControll : MonoBehaviour {

    [SerializeField] private float ThrustSpeed = 50f; //The speed of the ball thrust
    [SerializeField] private Rigidbody rigidbodyBall; //Get the rigidbody of the ball.
    [SerializeField] private float minCamDistance = 3f; //Get the min camera distance on how much the player ball can move from camera.
    [SerializeField] private float maxCamDistance = 5f; //Get the max camera distance on how much the player ball can move from camera.
    private int y__standard_rotation = 0;

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
   

    public AudioSource audiosSourceFinalSounds;   

    
    public GameObject completeGameOverUI;
    public GameObject completeGameWonUI;
    public GameObject buttonContinue;

    private int currentSceneIndex; //This will get your current scene.

    public delegate void OnPlayerDeath(bool status);
    public static event OnPlayerDeath onPlayerdeath;

    private void OnEnable()
    {
        AdManager.playerContinue += playerContinue;
        Resume.onGameResume += restoreCollider;       
    }

    private void OnDisable()
    {
        AdManager.playerContinue -= playerContinue;
        Resume.onGameResume -= restoreCollider;      
    }

    void Start() {
        completeGameOverUI.gameObject.SetActive(false);
        completeGameWonUI.gameObject.SetActive(false);
    }

    void Update() {


        Vector2 deltaPos = Vector2.zero;

        if (Input.GetMouseButton(0)) {
            Vector2 currentMousePos = Input.mousePosition;

            if (lastMousePos == Vector2.zero)
                lastMousePos = currentMousePos;

            deltaPos = currentMousePos - lastMousePos;
            lastMousePos = currentMousePos;

            Vector3 force = new Vector3(deltaPos.x, 0, deltaPos.y) * ThrustSpeed;
            rigidbodyBall.AddForce(force);


           // transform.rotation =  Quaternion.LookRotation(GetComponent<Rigidbody>().velocity);
            
            Debug.Log(deltaPos.x);

            if (deltaPos.x < -10)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -65, 0), Time.deltaTime * 5);
            if (deltaPos.x > 10)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 65, 0), Time.deltaTime * 5);
            if (deltaPos.x > -10 && deltaPos.x < 10)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 5);


        } else {
            
            lastMousePos = Vector2.zero;           
           // StartCoroutine(mouseLeft());
        }


    }
    private void FixedUpdate()
    {
        rigidbodyBall.MovePosition(transform.position + Vector3.forward * AutoMovementSpeed * Time.fixedDeltaTime);

    }

    void LateUpdate()
    {

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

    #region collisions
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "KillPlayer") {
            gameoverGUI = true;
            /*this.gameObject.GetComponentInChildren<Renderer> ().enabled = false;			
			foreach (Renderer r in GetComponentsInChildren<Renderer>())
			r.enabled = false;
			Destroy (GameObject.FindWithTag("BackgroundMusic"));*/
            this.gameObject.GetComponent<Collider>().enabled = false;
            audiosSourceFinalSounds.PlayOneShot(GameOverSound, 2.7F);
            Die();
        }

        if (col.gameObject.tag == "WinGame") {
            wingameGUI = true;
            this.gameObject.GetComponentInChildren<Renderer>().enabled = false;
            this.gameObject.GetComponentInChildren<Collider>().enabled = false;
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
                r.enabled = false;
            Destroy(GameObject.FindWithTag("BackgroundMusic"));
            Destroy(GameObject.FindWithTag("BullSounds"));
            audiosSourceFinalSounds.PlayOneShot(WinGameSound, 2.7F);
            Win();
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "KillPlayer")
        {
            gameoverGUI = true;
            /* this.gameObject.GetComponentInChildren<Renderer>().enabled = false;             
             foreach (Renderer r in GetComponentsInChildren<Renderer>())
                 r.enabled = false;
             Destroy(GameObject.FindWithTag("BackgroundMusic"));*/
            this.gameObject.GetComponent<Collider>().enabled = false;
            audiosSourceFinalSounds.PlayOneShot(GameOverSound, 2.7F);
            Die();
        }
    }
    #endregion

   

    private void checkRotation()
    {       
        Quaternion currentRotation = transform.rotation;
        Quaternion standardRotation = Quaternion.Euler(0, y__standard_rotation, 0);
        float rotationSpeed = 2;

        transform.rotation = Quaternion.Slerp(currentRotation, standardRotation, Time.deltaTime * rotationSpeed);

    }

    void Die() {
        completeGameOverUI.gameObject.SetActive(true);
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        onPlayerdeath(false);
        Time.timeScale = 0;
    }

    void Win() {
        completeGameWonUI.gameObject.SetActive(true);
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);      
    }

   

    private void playerContinue()
    {
        buttonContinue.SetActive(true);      
    } 
    private void restoreCollider()
    {
        StartCoroutine(restoreColliderProcess());
    }    
  
    #region coroutines
    IEnumerator mouseLeft()
    {
        yield return new WaitForSeconds(1);
        checkRotation();
    }
    IEnumerator restoreColliderProcess()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.GetComponent<Collider>().enabled = true;
    }    

    #endregion
}





