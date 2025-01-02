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
    public string filePath;
    // Update is called once per frame
    public void inizialize()
    {
        Data data = new Data();
        int trueCoins = FindObjectOfType<MenuController>().coins;
        GameSessionEndController controller = GetComponent<GameSessionEndController>();
        if (controller == null)
        {
            Debug.Log("controller nullo");
            return;
        }

        data.coin = trueCoins;
        saveData(data);
    }
    void saveData(Data data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }

    public int LoadData()
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
}
