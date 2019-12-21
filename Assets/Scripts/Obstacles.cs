using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject partycleSystem;
    public delegate void OnAddCoins();
    public static event OnAddCoins onAddCoins;
    [SerializeField] private List<AudioClip> woodSounds;

    private void OnCollisionEnter (Collision other)
    {       
        if (other.gameObject.tag == "Player")
        {            
            onAddCoins();
            if(partycleSystem != null)
            partycleSystem.GetComponent<ParticleSystem>().Play();
            playSound();
        }
    }

    private void playSound()
    {
        int rand = Random.Range(0, woodSounds.Count);
        if(GetComponent<AudioSource>() != null)
        GetComponent<AudioSource>().PlayOneShot(woodSounds[rand]);
    }
}
