using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] Reward reward;
    [SerializeField] GameObject buttonImage;
    [SerializeField] GameObject unlockedImage;
    private List<bool> items;

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
        buttonImage.GetComponent<Image>().sprite = reward.spriteImage;             
    }

    private void Start()
    {
        /* if (DataManager.bullsUnlocked[reward.indexValue])
            activateItemUnlockedImage(); */
       /* items = DataManager.bullsUnlocked;
        Debug.Log(items[0]);*/
        
    }

    private void activateItemUnlockedImage()
    {
        unlockedImage.SetActive(true);
    }
}
