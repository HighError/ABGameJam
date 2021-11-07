using System;
using System.Collections.Generic;

[System.Serializable]
public class Mission
{
    public List<Hacker> Hackers;
    public int SuccessChance;
    public long StartMissionTicks;
    public long EndMissionTicks;
    public MissionData MissionData;
    public bool IsSuccess;

    public void StartMission()
    {
        foreach (var hacker in Hackers)
            hacker.IsBusy = true;

        StartMissionTicks = DateTime.Now.Ticks;
        EndMissionTicks = DateTime.Now.AddMinutes(MissionData.Minutes).Ticks;
        IsSuccess = UnityEngine.Random.Range(0, 101) < MissionData.SuccessChance;
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

        if (IsSuccess)
        {
            GameManager.Instance.PlayerData.SabotageProcent += MissionData.RewardProcent;
            GameManager.Instance.PlayerData.CurrentScore += MissionData.CalculateScore(true, MissionData.RewardProcent);
        }
        else
        {
            GameManager.Instance.PlayerData.LoseProcent += MissionData.LoseProcent;
            GameManager.Instance.PlayerData.CurrentScore += MissionData.CalculateScore(false, MissionData.RewardProcent);
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
    public int BaseScore;
    public double Minutes;
    public List<Enums.Specialization> Specializations;

    public int CalculateScore(bool isSuccessfully, int RewardChance)
    {
        if (isSuccessfully)
        {
            if (RewardChance >= 90) return (int)(BaseScore * 0.75f);
            else if (RewardChance >= 75) return BaseScore;
            else if (RewardChance >= 40) return (int)(BaseScore * 1.25f);
            else return (int)(BaseScore * 1.5f);
        }
        else
        {
            if (RewardChance >= 90) return (int)(-BaseScore * 1.25f);
            else if (RewardChance >= 75) return -BaseScore;
            else if (RewardChance >= 40) return (int)(-BaseScore * 0.8f);
            else return (int)(-BaseScore * 0.6f);
        }
    }
}