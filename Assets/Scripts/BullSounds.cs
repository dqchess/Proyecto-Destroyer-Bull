using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullSounds : MonoBehaviour
{
    [SerializeField] private AudioSource bullStepsAS;
    [SerializeField] private AudioSource bullSoundsAS;

    [SerializeField] private List<AudioClip> bullSounds;

    private void OnEnable()
    {
        InvokeRepeating("playBullSounds", 2, 5);
    }    
    private void playBullSounds()
    {
        int rand = Random.Range(0, bullSounds.Count);
        bullSoundsAS.PlayOneShot(bullSounds[rand]);
    }
}
