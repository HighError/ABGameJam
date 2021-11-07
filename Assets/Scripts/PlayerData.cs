using System;
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

    [HideInInspector] public City CurrentCity;
    [HideInInspector] public List<int> CurrentMissionsIds;

    [HideInInspector] public bool NewGameStarted;

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
        MaxHackers = 4;
        NoMusic = false;
        NoSound = false;
        SetRandomCity();
        CurrentMissionsIds = new List<int>();
    }

    private void SetRandomCity()
    {
        if (CurrentCity == null)
            CurrentCity = GameManager.Instance.Cache.GetCity("Nyonbans");
        else
        {
            City newCity;
            do
            {
                newCity = GameManager.Instance.Cache.GetRandomCity();
            } while (newCity.Name == CurrentCity.Name);
            CurrentCity = newCity;
        }
        EventSystem.CallOnOverlayUpdateNeeded();
    }

    public void NextLevel()
    {
        EventSystem.CallOnWindowsCloseNeeded();
        CurrentMissionsIds.Clear();
        CurrentMissions.Clear();

        SetRandomCity();
        GameManager.Instance.InstantiateWindow("NextLevelWindow");

        foreach (var hacker in HackerInfoData)
            hacker.IsBusy = false;

        LevelNumber++;
        SabotageProcent = 0;
        LoseProcent = 0;

        if (CurrentCity.Debaf == Enums.CityDebafs.StartLoseProc)
            LoseProcent = 10;

        if (CurrentCity.Debaf != Enums.CityDebafs.NoNewHacker)
            MaxHackers += UnityEngine.Random.Range(1, 2);

        EventSystem.CallOnUpdateScoreNeeded();
    }

    public void EndGame()
    {
        CurrentCity = null;
        EventSystem.CallOnWindowsCloseNeeded();
        GameManager.Instance.InstantiateWindow("LoseWindow");
    }

    #region SaveLoad
    private SaveData CreateSaveGameObject()
    {
        SaveData savedData = new SaveData();
        savedData.HackerInfoData = HackerInfoData;
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
        savedData.CurrentCity = CurrentCity;
        savedData.CurrentMissionsIds = CurrentMissionsIds;

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
            CurrentCity = savedData.CurrentCity;
            CurrentMissionsIds = savedData.CurrentMissionsIds;

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
    public City CurrentCity;
    public List<int> CurrentMissionsIds;
}