using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private  int coins;

    public delegate void OnBuySucced();
    public static event OnBuySucced onBuySucced;

  

    void Start()
    {
        coins = DataManager.coins;
    }

   
    public void unlockItem(Reward reward)
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
