using System.Collections.Generic;

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
}
