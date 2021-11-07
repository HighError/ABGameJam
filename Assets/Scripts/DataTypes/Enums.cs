using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums
{
    public enum Specialization
    {
        Robotics,
        Servers,
        LocalPoints,
        Stelth,
        Distraction
    }

    public enum Notification
    {
        Mission,
        Error
    }

    public enum CityDebafs
    {
        None,
        NoNewHacker,
        StartLoseProc,
        SuccessChanceMinus10,
        SuccessChanceMinus15
    }
}
