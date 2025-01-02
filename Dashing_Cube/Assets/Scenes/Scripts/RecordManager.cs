using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Record
{
    public int record1;
    public int record2;
    public int record3;
}

public class RecordManager : MonoBehaviour
{
    public int meters;
    private Record record = new Record();
    public string RecordFilePath;
    // Update is called once per frame
    public void inizializeRecord()
    {
        PlatformController controller = FindObjectOfType<PlatformController>();

        int[] mediumLevelRecords = LoadRecord();
        record.record1 = mediumLevelRecords[0];
        record.record2 = mediumLevelRecords[1];
        record.record3 = mediumLevelRecords[2];
        meters = controller.meters;
        if(meters > record.record3)
        {
            if(meters > record.record2)
                {
                    if(meters > record.record1)
                    {
                        record.record3 = record.record2;
                        record.record2 = record.record1;
                        record.record1 = meters;
                    }
                    else
                    {
                        record.record3 = record.record2;
                        record.record2 = meters;
                    }
                }
                else
                {
                    record.record3 = meters;
                }
        }

        RecordFilePath = Application.persistentDataPath + "/recordData.json";

        Debug.Log("" + meters);

        Debug.Log("" + record.record1);
        Debug.Log("" + record.record2);
        Debug.Log("" + record.record3);
        SaveRecord(record);
    }
    void SaveRecord(Record record)
    {
        string json = JsonUtility.ToJson(record, true);
        File.WriteAllText(RecordFilePath, json);
    }

    public int[] LoadRecord()
    {
        RecordFilePath = Application.persistentDataPath + "/recordData.json";
        string json = File.ReadAllText(RecordFilePath);
        Record record = JsonUtility.FromJson<Record>(json);
        Debug.Log("" + record.record1);
        Debug.Log("" + record.record2);
        Debug.Log("" + record.record3);
        int[] mediumLevelRecords = new int[] { record.record1, record.record2, record.record3 };
        
        return mediumLevelRecords;
    }
}
