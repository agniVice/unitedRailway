using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataData
{
    //public float Money;
    public float Tickets;
    public PlayerDataData(PlayerData playerData)
    {
        //Money = playerData.GetMoney();
        Tickets = playerData.GetTickets();
    }
}
