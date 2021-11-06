using System.Collections.Generic;
using UnityEngine;

public class Hacker
{
    public HackerStats Stats;
    public bool IsBusy;

    public struct HackerStats
    {
        public string Name;
        public string AvatarName;
        public List<Enums.Specialization> Specialization;
    }

    public static HackerStats CreateRandomStats()
    {
        HackerStats hackerStats = new HackerStats
        {
            Name = Consts.HACKER_NAMES[Random.Range(0, Consts.HACKER_NAMES.Length)],
            AvatarName = Consts.HACKER_AVATARS[Random.Range(0, Consts.HACKER_AVATARS.Length)],
            Specialization = new List<Enums.Specialization>()
        };
        for (int i = 0; i < Random.Range(1, 3);)
        {
            var specialization = (Enums.Specialization)Random.Range(0, (int)Enums.Specialization.Distraction + 1);
            if (hackerStats.Specialization.Contains(specialization))
            {
                continue;
            }
            hackerStats.Specialization.Add(specialization);
            i++;
        }
        return hackerStats;
    }
}
