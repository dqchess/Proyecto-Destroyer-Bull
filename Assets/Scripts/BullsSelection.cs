using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullsSelection : MonoBehaviour
{   
    public List<GameObject> bulls_inGame;
    public List<GameObject> bulls_shop;
    private int count;
    [SerializeField] private GameObject buttonSelect;

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

        else if (count > bulls_inGame.Count - 1)
            count = 0;

          if(count!= 0)
          checkItemUnlocked();
          else
            buttonSelect.SetActive(true);
        

        for (int i = count; i < bulls_shop.Count; i++)
        {
            bulls_shop[count].SetActive(true);
        }
       
    }

    public void select() // permite activar cualquier toro en escena por mas q no este desbloqueado, arreglar
    {
       foreach(GameObject bull in bulls_inGame)
       {
          bull.SetActive(false);
       }

        if (count !=0 && DataManager.bullsUnlocked[count - 1])
            bulls_inGame[count].SetActive(true);
        else
            bulls_inGame[0].SetActive(true);
    }

    private void checkItemUnlocked()
    {     
        
      if (!DataManager.bullsUnlocked[count - 1]) 
          buttonSelect.SetActive(false);
           
      else
            buttonSelect.SetActive(true);          

    }

    }
