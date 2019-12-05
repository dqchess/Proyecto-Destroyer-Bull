using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullsSelection : MonoBehaviour
{
    public List<Bull> bulls;
    public List<GameObject> bulls_inGame;
    public List<GameObject> bulls_shop;
    private int count;   

    private void Start()
    {
        count = 0;
    }

    public void bullChosen(int value)
    {
        Debug.Log("toco boton");
        bulls_shop[count].SetActive(false);
        count += value;
        Debug.Log(count);
        if (count < 0)
            count = bulls.Count - 1;

        if (count > bulls.Count - 1)
            count = 0;

        for (int i = count; i < bulls_shop.Count; i++)
        {
            bulls_shop[count].SetActive(true);
        }
    }

        public void select()
        {
        bulls_inGame[count].SetActive(true);
        }


    }
