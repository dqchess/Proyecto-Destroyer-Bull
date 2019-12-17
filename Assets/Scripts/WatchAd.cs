using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchAd : MonoBehaviour
{
    public delegate void ShowAd();
    public static event ShowAd showAd;


    public void showAnAd()
    {      
        showAd();
    }
}
