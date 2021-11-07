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

    [HideInInspector] public bool NoMusic;
    [HideInInspector] public bool NoSound;

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
        MaxScore = 0;
        MaxHackers = 2;
        NoMusic = false;
        NoSound = false;
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
        savedData.HackerInfoData =HackerInfoData;
        savedData.LevelNumber = LevelNumber;
        savedData.SabotageProcent = SabotageProcent;
        savedData.LoseProcent = LoseProcent;
        savedData.CompletedMissionsCount = CompletedMissionsCount;
        savedData.CurrentScore = CurrentScore;
        savedData.MaxScore = MaxScore;
        savedData.MaxHackers = MaxHackers;
        savedData.recrutHackerList = recrutHackerList;
        savedData.CurrentMissions = CurrentMissions;
        savedData.NoMusic = NoMusic;
        savedData.NoSound = NoSound;
        savedData.RectuteUpdateTime = GameManager.Instance.Updater.GetRecruteUpdateTime();

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

            HackerInfoData = savedData.HackerInfoData;
            LevelNumber = savedData.LevelNumber;
            SabotageProcent = savedData.SabotageProcent;
            LoseProcent = savedData.LoseProcent;
            CompletedMissionsCount = savedData.CompletedMissionsCount;
            CurrentScore = savedData.CurrentScore;
            MaxScore = savedData.MaxScore;
            MaxHackers = savedData.MaxHackers;
            recrutHackerList = savedData.recrutHackerList;
            CurrentMissions = savedData.CurrentMissions;
            NoMusic = savedData.NoMusic;
            NoSound = savedData.NoSound;
            GameManager.Instance.Updater.SetRecruteUpdateTime(savedData.RectuteUpdateTime);

            AdditionalAfterLoadActions();

            Debug.Log("Game Loaded");
        }
        else
        {
            CreateNewData();

            Debug.Log("No game saved!");
        }
    }
    #endregion

    private void AdditionalAfterLoadActions()
    {
        EventSystem.CallOnRecordUpdateNeeded();
    }
}

[System.Serializable]
public class SaveData
{
    public List<Hacker> HackerInfoData;
    public int LevelNumber;
    public int SabotageProcent;
    public int LoseProcent;
    public int CompletedMissionsCount;
    public int CurrentScore;
    public int MaxScore;
    public int MaxHackers;

    public List<Hacker.HackerStats> recrutHackerList;
    public List<Mission> CurrentMissions;

    public bool NoMusic;
    public bool NoSound;

    public float RectuteUpdateTime;
}