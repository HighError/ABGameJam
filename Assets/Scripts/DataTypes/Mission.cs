using System;
using System.Collections.Generic;

public class Mission
{
    public List<Hacker> Hackers;
    public int SuccessChance;
    public long EndMissionTicks;
    public MissionData MissionData;

    public void StartMission()
    {
        foreach (var hacker in Hackers)
            hacker.IsBusy = true;

        EndMissionTicks = DateTime.Now.AddMinutes(MissionData.Minutes).Ticks;
    }

    public bool CheckCompleted()
    {
        if (DateTime.Now.Ticks > EndMissionTicks)
        {
            CompleteMission();
            return true;
        }
        return false;
    }

    public void CompleteMission()
    {
        GameManager.Instance.PlayerData.CurrentMissions.Remove(this);
        foreach (var hacker in Hackers)
            hacker.IsBusy = false;

        if (UnityEngine.Random.Range(0, 101) < MissionData.SuccessChance)
        {
            GameManager.Instance.PlayerData.SabotageProcent += MissionData.RewardProcent;
            GameManager.Instance.PlayerData.CurrentScore += MissionData.RewardProcent; //TODO: set correct score
        }
        else
        {
            GameManager.Instance.PlayerData.LoseProcent += MissionData.LoseProcent;
            GameManager.Instance.PlayerData.CurrentScore -= MissionData.LoseProcent; //TODO: set correct score
        }
        EventSystem.CallOnUpdateScoreNeeded();
    }
}

[System.Serializable]
public class MissionData
{
    public int Id;
    public string Name;
    public int SuccessChance;
    public int LoseProcent;
    public int RewardProcent;
    public double Minutes;
    public List<Enums.Specialization> Specializations;
}