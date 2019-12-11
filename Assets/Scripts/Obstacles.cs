using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    public delegate void OnAddCoins();
    public static event OnAddCoins onAddCoins;

    private void OnCollisionEnter (Collision other)
    {       
        if (other.gameObject.tag == "Player")
        {            
            onAddCoins();
        }
    }
}
