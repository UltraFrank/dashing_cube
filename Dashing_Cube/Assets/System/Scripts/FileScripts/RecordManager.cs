using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Record
{
    public int recordEasy1 = 0;
    public int recordEasy2;
    public int recordEasy3;

    public int recordMedium1;
    public int recordMedium2;
    public int recordMedium3;

    public int recordHard1;
    public int recordHard2;
    public int recordHard3;
}

public class RecordManager : MonoBehaviour
{
    public int meters;
    private Record record = new Record();
    public string RecordFilePath;

    public void inizializeRecord(int meters)
    {
        //MenuController controller = FindObjectOfType<MenuController>();
        MenuController menuController = FindObjectOfType<MenuController>();

        int[] easyLevelRecords = LoadEasyRecord();
        int[] mediumLevelRecords = LoadMediumRecord();
        int[] hardLevelRecords = LoadHardRecord();

        record.recordEasy1 = easyLevelRecords[0];
        record.recordEasy2 = easyLevelRecords[1];
        record.recordEasy3 = easyLevelRecords[2];

        record.recordMedium1 = mediumLevelRecords[0];
        record.recordMedium2 = mediumLevelRecords[1];
        record.recordMedium3 = mediumLevelRecords[2];

        record.recordHard1 = hardLevelRecords[0];
        record.recordHard2 = hardLevelRecords[1];
        record.recordHard3 = hardLevelRecords[2];

        Debug.Log(menuController.isEasy);
        Debug.Log(menuController.isNormal);
        Debug.Log(menuController.isHard);

        if (menuController.isEasy)
        {
            Debug.Log("ciao");
            if (meters > record.recordEasy3)
            {
                if (meters > record.recordEasy2)
                {
                    if (meters > record.recordEasy1)
                    {
                        record.recordEasy3 = record.recordEasy2;
                        record.recordEasy2 = record.recordEasy1;
                        record.recordEasy1 = meters;
                    }
                    else
                    {
                        record.recordEasy3 = record.recordEasy2;
                        record.recordEasy2 = meters;
                    }
                }
                else
                {
                    record.recordEasy3 = meters;
                }
            }
        }
        else if(menuController.isNormal)
        {
            Debug.Log("ciao1");
            if (meters > record.recordMedium3)
            {
                if (meters > record.recordMedium2)
                {
                    if (meters > record.recordMedium1)
                    {
                        Debug.Log("Blabla");
                        record.recordMedium3 = record.recordMedium2;
                        record.recordMedium2 = record.recordMedium1;
                        record.recordMedium1 = meters;
                    }
                    else
                    {
                        record.recordMedium3 = record.recordMedium2;
                        record.recordMedium2 = meters;
                    }
                }
                else
                {
                    record.recordMedium3 = meters;
                }
            }
        }
        else if(menuController.isHard)
        {
            Debug.Log("ciao2");
            if (meters > record.recordHard3)
            {
                if (meters > record.recordHard2)
                {
                    if (meters > record.recordHard1)
                    {
                        record.recordHard3 = record.recordHard2;
                        record.recordHard2 = record.recordHard1;
                        record.recordHard1 = meters;
                    }
                    else
                    {
                        record.recordHard3 = record.recordHard2;
                        record.recordHard2 = meters;
                    }
                }
                else
                {
                    record.recordHard3 = meters;
                }
            }
        }
        

        RecordFilePath = Application.persistentDataPath + "/recordData.json";

        Debug.Log("" + meters);


        SaveRecord(record);
    }
    void SaveRecord(Record record)
    {
        string json = JsonUtility.ToJson(record, true);
        File.WriteAllText(RecordFilePath, json);
    }

    public int[] LoadEasyRecord()
    {
        RecordFilePath = Application.persistentDataPath + "/recordData.json";
        if (!File.Exists(RecordFilePath))
        {
            Record record1 = new Record();
            SaveRecord(record1);
        }
        string json = File.ReadAllText(RecordFilePath);
        Record record = JsonUtility.FromJson<Record>(json);
        int[] easyLevelRecords = new int[] { record.recordEasy1, record.recordEasy2, record.recordEasy3 };

        return easyLevelRecords;
    }

    public int[] LoadMediumRecord()
    {
        RecordFilePath = Application.persistentDataPath + "/recordData.json";
        if (!File.Exists(RecordFilePath))
        {
            Record record1 = new Record();
            SaveRecord(record1);
        }
        string json = File.ReadAllText(RecordFilePath);
        Record record = JsonUtility.FromJson<Record>(json);
        int[] mediumLevelRecords = new int[] { record.recordMedium1, record.recordMedium2, record.recordMedium3 };
        
        return mediumLevelRecords;
    }

    public int[] LoadHardRecord()
    {
        RecordFilePath = Application.persistentDataPath + "/recordData.json";
        if (!File.Exists(RecordFilePath))
        {
            Record record1 = new Record();
            SaveRecord(record1);
        }
        string json = File.ReadAllText(RecordFilePath);
        Record record = JsonUtility.FromJson<Record>(json);
        int[] hardLevelRecords = new int[] { record.recordHard1, record.recordHard2, record.recordHard3 };

        return hardLevelRecords;
    }
}
