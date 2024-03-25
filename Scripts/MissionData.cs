using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MissionData
{
    public int IsMapUnlocked;
    public int BestTime;
    public int CountStars;
    public int CountPlays;

    public MissionData(Map map)
    {
        if (map.GetUnlock())
            IsMapUnlocked = 1;
        else
            IsMapUnlocked = 0;
        BestTime = map.GetTime();
        CountStars = map._stars;
        CountPlays = map.timesPlayed;
    }
}
