using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Bull",menuName ="New Bull")]
public class Bull :ScriptableObject
{
    public string name;
    public int shopValue;
    public GameObject inGameGameObject;
    public GameObject inStoreGameObject;
    public Sprite spriteImage;
    public int value;
}
