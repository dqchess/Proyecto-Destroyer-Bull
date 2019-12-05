using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullsSelection : MonoBehaviour
{
    public List<Bull> bulls;
    public List<GameObject> bull_shop;
    private int count;
    private string bullChosenName;

    private void Start()
    {
        count = 0;
    }

    public void bullChosen(int value)
    {
        bull_shop[count].SetActive(false);
        count += value;

        if (count < 0)
            count = bulls.Count - 1;

        if (count > bulls.Count - 1)
            count = 0;

        for (int i = count; i < bull_shop.Count; i++)
        {
            bull_shop[count].SetActive(true);
        }


    }

    public void select()
    {
        foreach (Bull bull in bulls)
        {
            if (bull.inGameGameObject.gameObject.name == bullChosenName)
                bull.inGameGameObject.gameObject.SetActive(true);
        }
    }


}