using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [HideInInspector] public List<Hacker> HackerInfoData;
    [HideInInspector] public int LevelNumber;
    [HideInInspector] public int SabotageProcent;
    [HideInInspector] public int CompletedMissionsCount;

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
    }

    private int GetStartSabotageProcentByLevel(int levelNumber)
    {
        //TODO: create sabotage proc balance
        return 50;
    }
}