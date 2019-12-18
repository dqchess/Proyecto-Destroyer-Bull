using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
    private bool playerIsAlive;

    private RewardedAd rewardedAd;
    private string rewardedAdID = "ca-app-pub-3940256099942544/5224354917";

    public delegate void PlayerRewarded(bool decision);
    public static event PlayerRewarded playerRewarded;

    public delegate void PlayerCotinue();
    public static event PlayerCotinue playerContinue;

    private void OnEnable()
    {
        WatchAd.showAd += userChoseToWatchAd;
        BallControll.onPlayerdeath += updatePlayerStatus;
    }

    private void OnDisable()
    {
        WatchAd.showAd -= userChoseToWatchAd;
        BallControll.onPlayerdeath -= updatePlayerStatus;
    }

    public void Start()
    {
        playerIsAlive = true;

        MobileAds.Initialize(initStatus => { });

        this.rewardedAd = new RewardedAd(rewardedAdID);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }



    public void HandleRewardedAdLoaded(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, System.EventArgs args)
    {
        this.createAndLoadRewardedAd();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        if (playerIsAlive)
            playerRewarded(true);
        else
            playerContinue();
    }

    private void createAndLoadRewardedAd()
    {       
        AdRequest request = new AdRequest.Builder().Build();       
        this.rewardedAd.LoadAd(request);
    }
    public void userChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    private void updatePlayerStatus()
    {
        playerIsAlive = false;
    }
}
