using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    public GameObject shop;

    public void activateShop()
    {
        shop.SetActive(true);
    }

    public void deactivateShop()
    {
        shop.SetActive(false);
    }
}
