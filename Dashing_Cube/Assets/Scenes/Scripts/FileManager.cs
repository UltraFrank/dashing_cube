using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int coin;
}
public class FileManager : MonoBehaviour
{
    private string filePath = "C:/Users/Utente/AppData/LocalLow/DefaultCompany/Dashing_Cube/gameData.json";
    // Update is called once per frame
    public void inizialize()
    {
        Data data = new Data();
        
        int trueCoins = FindObjectOfType<MenuController>().coins;

        filePath = Application.persistentDataPath + "/gameData.json";
        Debug.Log("" + filePath);
        data.coin = trueCoins;
        Debug.Log("" + data.coin);
        saveData(data);
    }
    void saveData(Data data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    public int LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            Data coins = JsonUtility.FromJson<Data>(json);
            Debug.Log(coins.coin);
            return coins.coin;
        }
        else
            Debug.Log("Filepath non corretto :" + filePath);
        return 0;
    }
}
