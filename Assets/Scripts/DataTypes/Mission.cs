using System;
using System.Collections.Generic;

public class Mission
{
    public Hacker Hacker;
    public int SabotageProcent;
    public int SuccessChance;
    public long EndMissionTicks;
    public MissionData MissionData;

    public void StartMission()
    {

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
        GameManager.Instance.PlayerData.SabotageProcent += SabotageProcent;
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