using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
    public GameObject male;
    private Animator animator;
    private Rigidbody rb;
    public List<GameObject> parts;

    void Start()
    {
        animator = male.GetComponent<Animator>();
        rb = male.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag =="Male" || other.gameObject.tag == "Kill Player")
        {
            animator.enabled = false;
            rb.isKinematic = false;   
            foreach(GameObject gameObject in parts)
            {
                gameObject.GetComponent<Collider>().enabled = true;
            }
        }

        if (other.gameObject.tag == "Disable")
            male.gameObject.SetActive(false);       
    }
   
}
