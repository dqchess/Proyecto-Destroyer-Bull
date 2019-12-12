using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField] Reward reward;
    private Sprite sprite;

    private void Start()
    {
        sprite = reward.spriteImage;
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
