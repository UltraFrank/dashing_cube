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
        filePath = Application.persistentDataPath + "/gameData.json";
        string json = File.ReadAllText(filePath);
        Data coins = JsonUtility.FromJson<Data>(json);
        Debug.Log(coins.coin);
        return coins.coin;
    }
}
