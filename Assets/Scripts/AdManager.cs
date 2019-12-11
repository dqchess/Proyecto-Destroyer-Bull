using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Advertisements;



public class AdManager : MonoBehaviour
{
    private string playsStoreID = "3394222";
    private string apppleStoreID = "3394223";
    private string rewardedVideoID = "rewardedVideo";

    //set false if launching in playStore
    public bool isPlayStore;
    //set false when lauchinga game
    public bool isTest;
    public static AdManager instace;

    private void Start()
    {
        initializeMonetization();
        instace = this;
    }

    private void initializeMonetization()
    {
        if(isPlayStore)
        {
            Advertisement.Initialize(playsStoreID, isTest);
            return;
        }
        Advertisement.Initialize(apppleStoreID, isTest);
    }

    public void playRewardedVideo()
    {
        if(!Advertisement.IsReady(rewardedVideoID))
        {
            return;
        }
        
      Advertisement.Show(rewardedVideoID);
    }


    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            // Reward the player
        }
        else if (result == ShowResult.Skipped)
        {
            Debug.LogWarning("The player skipped the video - DO NOT REWARD!");
        }
        else if (result == ShowResult.Failed)
        {
            Debug.LogError("Video failed to show");
        }
    }

}

