using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class DataManager : MonoBehaviour
{
    public static int coins;
    public static bool Bull_Red_Unlock;
    public static bool Bull_Yellow_Unlock;
    public static bool Bull_Blue_Unlock;
    public static bool Bull_Black_Unlock;
    public static bool Bull_Green_Unlock;
    public static bool Bull_Pink_Unlock;
    public static bool Bull_Purple_Unlock;
    public static bool Bull_Orange_Unlock;
    public static bool Bull_White_Unlock;
    public static List<bool> bullsUnlocked = new List<bool>();

    private static string fileName = "/matigamedata.dat";

    private void Awake()
    {
        bullsUnlocked.Add(Bull_Red_Unlock);
        bullsUnlocked.Add(Bull_Yellow_Unlock);
        bullsUnlocked.Add(Bull_Blue_Unlock);
        bullsUnlocked.Add(Bull_Black_Unlock);
        bullsUnlocked.Add(Bull_Green_Unlock);
        bullsUnlocked.Add(Bull_Pink_Unlock);
        bullsUnlocked.Add(Bull_Purple_Unlock);
        bullsUnlocked.Add(Bull_Orange_Unlock);
        bullsUnlocked.Add(Bull_White_Unlock);
      
        load();

    }
    
    public static void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + fileName);

        GameData gameData = new GameData();
        gameData.coins = coins;
        gameData.Bull_Red_Unlock = bullsUnlocked[0];
        gameData.Bull_Yellow_Unlock = bullsUnlocked[1];
        gameData.Bull_Blue_Unlock = bullsUnlocked[2];
        gameData.Bull_Black_Unlock = bullsUnlocked[3];
        gameData.Bull_Green_Unlock = bullsUnlocked[4];
        gameData.Bull_Pink_Unlock = bullsUnlocked[5];
        gameData.Bull_Purple_Unlock = bullsUnlocked[6];
        gameData.Bull_Orange_Unlock = bullsUnlocked[7];
        gameData.Bull_White_Unlock = bullsUnlocked[8];


        bf.Serialize(file, gameData);
        file.Close();
    }
    public static void load()
    {
        if (File.Exists(Application.persistentDataPath + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + fileName, FileMode.Open);
            GameData gamedata = (GameData)bf.Deserialize(file);

            coins = gamedata.coins;
            bullsUnlocked[0] = gamedata.Bull_Red_Unlock;
            bullsUnlocked[1] = gamedata.Bull_Yellow_Unlock;
            bullsUnlocked[2] = gamedata.Bull_Blue_Unlock;
            bullsUnlocked[3] = gamedata.Bull_Black_Unlock;
            bullsUnlocked[4] = gamedata.Bull_Green_Unlock;
            bullsUnlocked[5] = gamedata.Bull_Pink_Unlock;
            bullsUnlocked[6] = gamedata.Bull_Purple_Unlock;
            bullsUnlocked[7] = gamedata.Bull_Orange_Unlock;
            bullsUnlocked[8] = gamedata.Bull_White_Unlock;
           

            file.Close();
        }
        else
            save();
    }

    public static void updateCoins(int newCoins)
    {        
        coins += newCoins;
        Debug.Log("coins: " + coins);
        Debug.Log("newcoins: " + newCoins);
        save();
    }
    public static void unlockBull(int index)
    {
        bullsUnlocked[index] = true;
        save();
    }
}

[System.Serializable]
public class GameData
{
    public int coins;
    public bool Bull_Red_Unlock;
    public bool Bull_Yellow_Unlock;
    public bool Bull_Blue_Unlock;
    public bool Bull_Black_Unlock;
    public bool Bull_Green_Unlock;
    public bool Bull_Pink_Unlock;
    public bool Bull_Purple_Unlock;
    public bool Bull_Orange_Unlock;
    public bool Bull_White_Unlock;   

}
