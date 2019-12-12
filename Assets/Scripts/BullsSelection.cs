using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullsSelection : MonoBehaviour
{   
    public List<GameObject> bulls_inGame;
    public List<GameObject> bulls_shop;
    private int count;   

    private void Start()
    {
        count = 0;
    }

    public void bullChosen(int value)
    {        
        bulls_shop[count].SetActive(false);
        count += value;        
        if (count < 0)
            count = bulls_inGame.Count - 1;

        if (count > bulls_inGame.Count - 1)
            count = 0;

        for (int i = count; i < bulls_shop.Count; i++)
        {
            bulls_shop[count].SetActive(true);
        }

        /*bullsUnlocked es la lista static de la clase dataManager
         * 
         * if(count != 1)
         * {
         * if(bullunlocked[count -1])
         * botonSelect.SetActive(True)
         * }*/
    }

        public void select()
        {
        bulls_inGame[count].SetActive(true);
        }


    }
