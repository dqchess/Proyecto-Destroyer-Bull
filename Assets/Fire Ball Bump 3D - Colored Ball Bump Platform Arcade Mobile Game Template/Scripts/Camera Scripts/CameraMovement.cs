using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	/*
	 * This script will make the camera moves by itself forward. Be sure that the camera rotation is Y: 0 or near.
	 * The camera will always needs to be facing forward to move so it needs to be Y: 0 as the rotation.
	 * It needs to be attached with the Main Camera and be sure the camera have a Rigidbody 3D with the Gravity disabled.
	 * It is important that you also set the speed of the camera at the 'Auto Movement Speed' in order to move.
	*/

	public int AutoMovementSpeed = 3; //The movement speed of the camera and can be of your choice. MAKE SURE IT'S THE SAME AS THE PLAYERS.
	[SerializeField] private Rigidbody rigidbodyCamera; //Get the rigidbody of the camera.
	//public Vector3 userDirection = Vector3.right;

	public void Update() {
		//transform.Translate(userDirection * AutoMovementSpeed * Time.deltaTime); 
		rigidbodyCamera.velocity = Vector3.forward * AutoMovementSpeed;
	}
}