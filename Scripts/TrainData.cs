using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainData
{
    public int upgradeLvl;
    public float repair;
    public string firstWay;
    public string secondWay;

    public TrainData(TrainScript train)
    {
        upgradeLvl = train.upgradeLvl;
        repair = train.newRepair;
        firstWay = train.way[0].gameObject.name;
        secondWay = train.way[1].gameObject.name;
    }
}
