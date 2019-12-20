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
    public List<AudioClip> sounds;

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

            playSound();
            onAddCoins();
        }
    }

    private void playSound()
    {
        int rand1 = Random.Range(0, 100);
        if(rand1 <50)
        {
            int rand = Random.Range(0, sounds.Count);
            GetComponent<AudioSource>().PlayOneShot(sounds[rand]);
        }
    }
       
   
}
