using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Reward",menuName ="New Reward")]
public class Reward1 :ScriptableObject
{
    public string name;
    public int shopValue;   
    public Sprite spriteImageShop;
    public int indexValue;
    public Sprite spriteBullSelection;
}
