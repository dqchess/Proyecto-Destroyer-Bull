using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGameObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.SetActive(true);
            }
        }
        
    }
}
