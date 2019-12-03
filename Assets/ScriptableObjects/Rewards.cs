using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Reward",menuName ="New Reward")]
public class Rewards :ScriptableObject
{
    public string name;
    public int value;
    public Sprite spriteImage;
}
