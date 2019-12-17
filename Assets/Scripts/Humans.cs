using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humans : MonoBehaviour
{
    public GameObject male;
    public GameObject partycleSystem;
    private Animator animator;
    private Rigidbody rb;

    public delegate void OnAddCoins();
    public static event OnAddCoins onAddCoins;

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
        }  
        if(other.gameObject.tag == "Player")
        {
            if(partycleSystem != null)
            partycleSystem.GetComponent<ParticleSystem>().Play();

            onAddCoins();
        }
    }
   
}
