using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullsSelection : MonoBehaviour
{
    public List<GameObject> bullsMenu;
    public List<GameObject> bullsGame;
    private int count;
    private string bullChosenName;
   
    private void Start()
    {
        count = 0;
        bullChosenName = bullsMenu[0].name;        
    }

    public void bullChosen(int value)
    {
        bullsMenu[count].SetActive(false);
        count += value;

        if (count < 0)
            count = bullsMenu.Count-1;

        if (count > bullsMenu.Count - 1)
            count = 0;

        switch(count)
        {
            case 0:
                bullChosenName = bullsMenu[count].name;
                bullsMenu[count].SetActive(true);
                break;
            case 1:
                bullChosenName = bullsMenu[count].name;
                bullsMenu[count].SetActive(true);
                break;
            case 2:
                bullChosenName = bullsMenu[count].name;
                bullsMenu[count].SetActive(true);
                break;
        }       
    }

    public void select()
    {
        Debug.Log(bullChosenName);
       foreach(GameObject bull in bullsGame)
        {
            if (bull.gameObject.name == bullChosenName)
                bull.gameObject.SetActive(true);
        }
    }

    
}
