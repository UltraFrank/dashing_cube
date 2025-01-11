using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int coin;
    public bool[] areSkinsAcquired;
}

public class FileManager : MonoBehaviour
{
    public string filePath;
    [SerializeField] Color[] listOfColors;

    public void inizialize()
    {
        Data data = new Data();
        int trueCoins = LoadCoinsData();
        if (trueCoins != FindObjectOfType<MenuController>().coins)
            trueCoins = FindObjectOfType<MenuController>().coins;
        Debug.Log(trueCoins);
        bool[] savedSkinsAcquired = FindObjectOfType<ShopController>().isSkinAcquired;
        if(savedSkinsAcquired.Length == 0)
        {
            savedSkinsAcquired = new bool[] { true, false, false, false, false, false };
        }

        GameSessionEndController controller = GetComponent<GameSessionEndController>();
        if (controller == null)
        {
            Debug.Log("controller nullo");
            return;
        }


        data.coin = trueCoins;
        data.areSkinsAcquired = savedSkinsAcquired;

        saveData(data);
    }
    void saveData(Data data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    public int LoadCoinsData()
    {
        filePath = Application.persistentDataPath + "/gameData.json";
        if(!File.Exists(filePath)) 
        {
            inizialize();
        }
        string json = File.ReadAllText(filePath);
        Data coins = JsonUtility.FromJson<Data>(json);
        return coins.coin;
    }

    public bool[] LoadShopData()
    {
        filePath = Application.persistentDataPath + "/gameData.json";
        if (!File.Exists(filePath))
        {
            inizialize();
        }
        string json = File.ReadAllText(filePath);
        Data skins = JsonUtility.FromJson<Data>(json);
        return skins.areSkinsAcquired;
    }
}
