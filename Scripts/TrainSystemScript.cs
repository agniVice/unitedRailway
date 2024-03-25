using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainSystemScript : MonoBehaviour
{
    [Header("Links")]
    public PriceManager priceManager;
    public MainSceneScript mainScript;
    public UserInterfaceScript uiScript;
    public TownRawManager trManager;
    public TrainScript tScript;
    public List<GameObject> train;
    public TrainInfo[] tInfo;
    [Space]
    public GameObject[] trainShopElements;
    public GameObject prefElementDepot;
    public GameObject contentDepot;
    public GameObject[] trainPrefab;
    public TrainScript trainSelected;
    [Space]
    [Header("Other")]
    public WagonScript[] wagonPref;//0-freight 1-passenger
    public float bottomsize;
    public bool isTrainSelectDepot;
    public GameObject camObject;
    [Space]
    [Header("Colors")]
    public Color[] hpcolor;
    public Color colorSelect;
    public Color colorNeutral;
    public Color colorSecondNeutral;
    public Color[] colorTypeTrain; // 0-universal 1-freight 2-passenger
    public void OpenTrainMenu()
    {
        if(tScript != null)
            uiScript.OpenTrainMenu(tScript);
    }
    public void BuyTrain(int id)
    {
        if (tInfo[id].isTicketCost)
        {
            if (mainScript.pData.CheckValue(tInfo[id].priceTrain, true))
                mainScript.pData.ChangeTickets(this.gameObject, -tInfo[id].priceTrain);
            else
            {
                uiScript.OpenDonateMenu();
                return;
            }
        }
        else
        {
            if (mainScript.pData.CheckValue(tInfo[id].priceTrain, false))
                mainScript.pData.ChangeMoney(this.gameObject, -tInfo[id].priceTrain);
            else
            {
                uiScript.OpenNoMoneyMenu(tInfo[id].priceTrain);
                return;
            }
        }
        if (train.Count < 30)
        {
            if (train.Count >= 8)
            {
                bottomsize += 83f;
                uiScript.contentDepot.offsetMin = new Vector2(0, -bottomsize);
            }
            train.Add(Instantiate(trainPrefab[id], gameObject.transform));
            tScript = train[train.Count - 1].GetComponent<TrainScript>();
            train[train.Count - 1].GetComponent<TrainScript>().AddDepotElement();
            tScript.trainId = train.Count-1;
            uiScript.CheckUnlockedTrains();
            uiScript.CloseMenu();
            trManager.OpenAll();
            trManager.tScript = tScript;
            if (tScript.typeTrain == "Freight Only!")
            {
                BuyWagon(0);
                BuyWagon(0);
                BuyWagon(0);
                BuyWagon(0);
            }
            else if (tScript.typeTrain == "Pass Only!")
            {
                BuyWagon(1);
                BuyWagon(1);
                BuyWagon(1);
                BuyWagon(1);
            }
            else if (tScript.typeTrain == "Universal")
            {
                BuyWagon(1);
                BuyWagon(1);
                BuyWagon(0);
                BuyWagon(0);
            }
            mainScript.pData.Source.clip = mainScript.pData.SoundMoneyDecrease;
            mainScript.pData.Source.Play();
            mainScript.camToTargetCoroutine = mainScript.CamToTarget(mainScript.camRig, true, mainScript.camController.zoomMax);
            mainScript.StartCoroutine(mainScript.camToTargetCoroutine);
        }
        else
            Debug.Log("Too Much Trains");

    }
    public int GetWagonCount()
    {
        int c = 0;
        foreach(GameObject t in train)
        {
            c += t.GetComponent<TrainScript>().wagon.Count;    
        }
        return c;
    }
    public void CloseElementDepot()
    {
        if (train.Count != 0)
        {
            for (int i = 0; i < train.Count; i++)
            {
                if (train[i].GetComponent<TrainScript>().isTrainSelectDepot == true)
                {
                    train[i].GetComponent<TrainScript>().CloseElementDepot();
                }
            }
        }
    }
    public void SelectElementDepot(TrainScript TrainScr)
    {
        for (int i = 0; i < train.Count; i++)
        {
            if (train[i] != TrainScr)
            {
                if (train[i].GetComponent<TrainScript>().isTrainSelectDepot == true)
                {
                    train[i].GetComponent<TrainScript>().CloseElementDepot();
                }
            }
        }
        tScript = TrainScr;
        TrainScr.SelectThis();
    }
    public void BuyWagon(int type)
    {
        for (int i = 0; i < wagonPref.Length; i++)
        {
            if (mainScript.pData.CheckValue(wagonPref[i].price, false))
            {
                mainScript.pData.ChangeMoney(wagonPref[i].gameObject, -wagonPref[i].price);
                tScript.BuyWagon(type);
                mainScript.pData.Source.clip = mainScript.pData.SoundMoneyDecrease;
                mainScript.pData.Source.Play();
                uiScript.CloseWagonBuyMenu();
                return;
            }
            else
                uiScript.OpenNoMoneyMenu(wagonPref[i].price);
                //uiScript.wagonButtonBuy[i].interactable = false;
        }
    }
    public void Repair() => tScript.Repair();
    public void Upgrade() => tScript.Upgrade();
    public void SellTrain() => tScript.SellTrain();
}
