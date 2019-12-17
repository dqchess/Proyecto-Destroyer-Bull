using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int coins;
    private const int COIN_VALUE = 50;
    public Text coinText;
    private bool playerWatchAd;
    

    private void OnEnable()
    {
        Obstacles.onAddCoins += addCoins;
        Humans.onAddCoins += addCoins;
        AdManager.playerRewarded += setLevelScore;
    }
    private void OnDisable()
    {
        Obstacles.onAddCoins -= addCoins;
        Humans.onAddCoins -= addCoins;
        AdManager.playerRewarded -= setLevelScore;
    }

    private void Start()
    {
        coins = 0;
        playerWatchAd = false;
    }
    private void Update()
    {
        coinText.text = coins.ToString();
    }
    private void addCoins()
    {
        coins += COIN_VALUE;
    }

    public void setLevelScore(bool decision)
    {
        if (!decision && !playerWatchAd)
            DataManager.updateCoins(coins);
        else if (decision)
        {
            coins *= 2;
            DataManager.updateCoins(coins);
            playerWatchAd = true;           
        }
        else
            return;       
    }
}
