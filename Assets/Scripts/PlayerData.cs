using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [HideInInspector] public List<Hacker> HackerInfoData;
    [HideInInspector] public int LevelNumber;
    [HideInInspector] public int SabotageProcent;
    [HideInInspector] public int CompletedMissionsCount;
    [HideInInspector] public int CurrentScore;
    [HideInInspector] public int MaxScore;

    [HideInInspector] public List<Mission> CurrentMissions;

    private void Awake()
    {
        CreateNewData();
    }

    private void CreateNewData()
    {
        HackerInfoData = new List<Hacker>();
        CurrentMissions = new List<Mission>();

        LevelNumber = 0;
        SabotageProcent = GetStartSabotageProcentByLevel(LevelNumber);
        CompletedMissionsCount = 0;
        CurrentScore = 0;
        MaxScore = 0;
    }

    private int GetStartSabotageProcentByLevel(int levelNumber)
    {
        //TODO: create sabotage proc balance
        return 50;
    }

        #region SaveLoad
    private SaveData CreateSaveGameObject()
    {
        SaveData savedData = new SaveData();
        savedData.MaxScore = MaxScore;

        return savedData;
    }

    public void SaveData()
    {
        SaveData savedData = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, savedData);
        file.Close();

        Debug.Log("Game Saved");
    }

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            SaveData savedData = (SaveData)bf.Deserialize(file);
            file.Close();

            MaxScore = savedData.MaxScore;

            Debug.Log("Game Loaded");
        }
        else
        {
            MaxScore = 0;

            Debug.Log("No game saved!");
        }
    }
    #endregion
}

[System.Serializable]
public class SaveData
{
    public int MaxScore;
}