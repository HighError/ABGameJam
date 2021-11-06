using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [HideInInspector] public List<Hacker> HackerInfoData;
    [HideInInspector] public int LevelNumber;
    [HideInInspector] public int SabotageProcent;
    [HideInInspector] public int LoseProcent;
    [HideInInspector] public int CompletedMissionsCount;
    [HideInInspector] public int CurrentScore;
    [HideInInspector] public int MaxScore;
    [HideInInspector] public int MaxHackers;

    [HideInInspector] public List<Hacker.HackerStats> recrutHackerList;
    [HideInInspector] public List<Mission> CurrentMissions;

    private void Awake()
    {
        //CreateNewData();
    }

    public void CreateNewData()
    {
        HackerInfoData = new List<Hacker>();
        CurrentMissions = new List<Mission>();
        recrutHackerList = new List<Hacker.HackerStats>();

        LevelNumber = 0;
        SabotageProcent = 0;
        LoseProcent = 0;
        CompletedMissionsCount = 0;
        CurrentScore = 0;
        MaxHackers = 2;
    }

    public void NextLevel()
    {
        EventSystem.CallOnWindowsCloseNeeded();
        GameManager.Instance.InstantiateWindow("NextLevelWindow");
        LevelNumber++;
        SabotageProcent = 0;
        LoseProcent = 0;
        MaxHackers += 1;
    }

    public void EndGame()
    {
        EventSystem.CallOnWindowsCloseNeeded();
        GameManager.Instance.InstantiateWindow("LoseWindow");
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
            //CHECK: Тут оновлюю панель рекорду
            EventSystem.CallOnRecordUpdateNeeded();

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