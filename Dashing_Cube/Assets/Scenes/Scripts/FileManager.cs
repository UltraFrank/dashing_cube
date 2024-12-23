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
    private string filePath;
    // Update is called once per frame
    public void inizialize()
    {
        Data data = new Data();
        GameSessionEndController controller = GetComponent<GameSessionEndController>();
        if (controller == null)
        {
            Debug.Log("controller nullo");
            return;
        }

        filePath = Application.persistentDataPath + "/gameData.json";
        Debug.Log("" + filePath);
        data.coin = controller.coins;
        saveData(data);
    }
    void saveData(Data data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, json);
    }
}
