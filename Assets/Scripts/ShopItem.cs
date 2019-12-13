using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] Reward reward;
    [SerializeField] GameObject buttonImage;
    [SerializeField] GameObject unlockedImage;   

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
         if (DataManager.bullsUnlocked[reward.indexValue])
            activateItemUnlockedImage();      
    }

    private void activateItemUnlockedImage()
    {
        unlockedImage.SetActive(true);
    }
}
