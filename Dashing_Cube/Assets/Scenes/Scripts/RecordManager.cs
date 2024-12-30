using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Record
{
    public int record;
}

public class RecordManager : MonoBehaviour
{
    public string RecordFilePath;
    // Update is called once per frame
    public void inizializeRecord()
    {
        Record record = new Record();
        GameSessionEndController controller = GetComponent<GameSessionEndController>();

        RecordFilePath = Application.persistentDataPath + "/recordData.json";
        
        int meters = controller.meters;
        if (controller == null)
        {
            Debug.Log("controller nullo");
            return;
        }

        record.record = meters;
        SaveRecord(record);
    }
    void SaveRecord(Record record)
    {
        string json = JsonUtility.ToJson(record, true);
        File.WriteAllText(RecordFilePath, json);
    }

    public int LoadRecord()
    {
        RecordFilePath = Application.persistentDataPath + "/recordData.json";
        string json = File.ReadAllText(RecordFilePath);
        Record record = JsonUtility.FromJson<Record>(json);
        Debug.Log("" + record.record);
        return record.record;
    }
}
