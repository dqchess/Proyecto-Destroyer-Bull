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
        createAndLoadRewardedAd();
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
        {
            playerContinue();
            updatePlayerStatus(true);
        }
           
    }

    private void createAndLoadRewardedAd()
    {
        this.rewardedAd = new RewardedAd(rewardedAdID);

        AdRequest request = new AdRequest.Builder().Build();

        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;


        this.rewardedAd.LoadAd(request);
    }
    public void userChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    private void updatePlayerStatus(bool status)
    {
        playerIsAlive = status;
    }
}
