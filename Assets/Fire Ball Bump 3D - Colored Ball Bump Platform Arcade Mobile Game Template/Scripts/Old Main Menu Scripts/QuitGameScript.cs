using UnityEngine;
using System.Collections;

public class QuitGameScript : MonoBehaviour {

	//This script can be added to a button with box collider so when you click it then the application will quit.

	void OnMouseDown() {
		Application.Quit();
		}
}
