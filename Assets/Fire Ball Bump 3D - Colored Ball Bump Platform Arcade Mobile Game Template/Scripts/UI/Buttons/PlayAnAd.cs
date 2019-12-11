using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnAd : MonoBehaviour
{
   public void playAd()
    {
        AdManager.instace.playRewardedVideo();
    }
}
