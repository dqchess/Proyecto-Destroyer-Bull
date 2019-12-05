using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullsSelection : MonoBehaviour
{
    public List<Bull> bulls;
    private int count;
    private string bullChosenName;

    private void Start()
    {
        count = 0;
    }

    public void bullChosen(int value)
    {
        bulls[count].inStoreGameObject.SetActive(false);
        count += value;

        if (count < 0)
            count = bulls.Count - 1;

        if (count > bulls.Count - 1)
            count = 0;

        for (int i = count; i < bulls.Count; i++)
        {
            bulls[count].inStoreGameObject.SetActive(true);
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