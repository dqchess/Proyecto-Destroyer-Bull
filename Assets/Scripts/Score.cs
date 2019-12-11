using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int coins;
    private int finalScore;
    private const int COIN_VALUE = 50;
    public Text coinText;
    public Text finalScoreText;

    private void OnEnable()
    {
        Obstacles.onAddCoins += addCoins;
        Humans.onAddCoins += addCoins;
        BallControll.onLevelFinished += setFinalScore;
    }
    private void OnDisable()
    {
        Obstacles.onAddCoins -= addCoins;
        Humans.onAddCoins -= addCoins;
        BallControll.onLevelFinished -= setFinalScore;
    }

    private void Start()
    {
        coins = 0;
        finalScore = 0;
    }
    private void Update()
    {
        coinText.text = coins.ToString();
    }
    private void addCoins()
    {
        coins += COIN_VALUE;
    }

    private void setFinalScore(bool decision)
    {
        if (decision)
        {
            finalScore += coins * 2;
        }
        else
            finalScore = coins;

        coinText.transform.parent.gameObject.SetActive(false);
        finalScoreText.text = finalScore.ToString();
        //aca guardamos score
    }
}
