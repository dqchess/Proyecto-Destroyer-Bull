using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BullSelectionItem : MonoBehaviour
{
    [SerializeField] Reward reward;
    [SerializeField] GameObject buttonImage;

    private void Awake()
    {
        buttonImage.GetComponent<Image>().sprite = reward.spriteBullSelection;
    }
}
