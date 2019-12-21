using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private  int coins;
    public Text coinText;
    public delegate void OnBuySucced(string name);
    public static event OnBuySucced onBuySucced;


    private void OnEnable()
    {
        DataManager.load();
        coins = DataManager.coins;
        coinText.text = coins.ToString();
    }
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
            onBuySucced(reward.name);// evento para activar sprite en el item de tienda para marcar q ya ha sido desbloqueado // revisar q se desbloquean todos
            coins -= reward.shopValue;
            DataManager.updateCoins(-reward.shopValue);
            coinText.text = coins.ToString();
        }
    }
}
