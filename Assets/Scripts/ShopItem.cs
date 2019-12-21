using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] Reward1 reward;
    [SerializeField] GameObject buttonImage;
    [SerializeField] GameObject unlockedImage;
    [SerializeField] Text valueText;

    private void OnEnable()
    {
        Shop.onBuySucced += activateItemUnlockedImage;
    }

    private void OnDisable()
    {
        Shop.onBuySucced -= activateItemUnlockedImage;
    }

    private void Awake()
    {
        buttonImage.GetComponent<Image>().sprite = reward.spriteImageShop;             
    }

    private void Start()
    {
        valueText.text = reward.shopValue.ToString();
         if (DataManager.bullsUnlocked[reward.indexValue])
            activateItemUnlockedImage(this.reward.name);      
    }

    private void activateItemUnlockedImage(string name)
    {
        if(reward.name == name)
        unlockedImage.SetActive(true);
    }
}
