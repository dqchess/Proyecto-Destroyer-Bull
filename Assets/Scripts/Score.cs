using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int coins;
    private const int COIN_VALUE = 50;
    public Text coinText;

    private void OnEnable()
    {
        Obstacles.onAddCoins += addCoins;
        Humans.onAddCoins += addCoins;
    }
    private void OnDisable()
    {
        Obstacles.onAddCoins += addCoins;
        Humans.onAddCoins += addCoins;
    }

    private void Start()
    {
        coins = 0;
    }
    private void Update()
    {
        coinText.text = coins.ToString();
    }
    private void addCoins()
    {
        coins += COIN_VALUE;
    }
}
