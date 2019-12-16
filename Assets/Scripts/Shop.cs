using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private  int coins;
    public Text coinText;
    public delegate void OnBuySucced();
    public static event OnBuySucced onBuySucced;

  

    void Start()
    {
        coins = DataManager.coins;
        coinText.text = coins.ToString();
    }

   
    public void unlockItem(Reward1 reward)
    {
        if(coins > reward.shopValue)
        {
            DataManager.unlockBull(reward.indexValue);
            onBuySucced();// evento para activar sprite en el item de tienda para marcar q ya ha sido desbloqueado
            coins -= reward.indexValue;
            DataManager.updateCoins(-reward.indexValue);
        }
    }
}
