using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerData : MonoBehaviour
{
    public TasksSystemScript taskSystem;
    public MainSceneScript mainScript;
    public float money;
    [SerializeField] private float newMoney;
    public float tickets;
    [SerializeField] private float newTickets;
    public bool[] trainUnlocked;
    private float elapsedTimeTickets;
    private float elapsedTimeMoney;
    private float timer = 3f;
    private float _spentMoney;
    private float _spentTickets;
    private float _earnedMoney;
    private float _earnedTickets;

    public int isAdEnable;

    [Header("Audio")]
    public AudioSource Source;
    public AudioClip SoundMoneyDecrease;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            Source = gameObject.GetComponent<AudioSource>();
            AudioManager.Instance.Sounds.Add(Source);
        }
        LoadData();
        isAdEnable = 1;
        if (PlayerPrefs.HasKey("AdDisabled"))
        {
            isAdEnable = PlayerPrefs.GetInt("AdDisabled");
        }
    }
    private void Update()
    {
        if (money != newMoney)
        {
            elapsedTimeMoney += Time.deltaTime;
            float perc = elapsedTimeMoney / timer;
            money = Mathf.Lerp(money, newMoney, Mathf.SmoothStep(0, 1, perc));
        }
        if (tickets != newTickets)
        {
            elapsedTimeTickets += Time.deltaTime;
            float percc = elapsedTimeTickets / timer;
            tickets = Mathf.Lerp(tickets, newTickets, Mathf.SmoothStep(0,1, percc));
        }
    }
    public void ChangeMoney(GameObject sender, float count, bool isEarn = true)
    {

        if (newMoney + count >= newMoney)
        {
            if (isEarn)
                taskSystem.GetInfo(this, count, "Money", true);
            _earnedMoney += count;
        }
        else
        {
            taskSystem.GetInfo(this, count, "Money", false);
            _spentMoney += count*-1;
        }
        elapsedTimeMoney = 0;
        newMoney += count;
        CheckManuValues();
        SaveData();
    }
    public void DisableAd()
    {
        PlayerPrefs.SetInt("AdDisabled", 1);
        if (SceneManager.GetActiveScene().buildIndex != 0)
            mainScript.uiScript.uiTween.noad_mui.gameObject.SetActive(false);
        isAdEnable = 0;
    }
    public void ChangeTickets(GameObject sender, float count, bool isEarn = true)
    {
        if (newTickets + count >= newTickets)
        {
            if (isEarn)
                taskSystem.GetInfo(this, count, "Tickets", true);
            _earnedTickets += count;
        }
        else
        {
            taskSystem.GetInfo(this, count, "Tickets", false);
            _spentTickets += count*-1;
        }
        elapsedTimeTickets = 0;
        newTickets += count;
        CheckManuValues();
        SaveData();
    }
    public void ChangeTrainState(int numTrain, bool openOrClose)
    {
        if (numTrain <= trainUnlocked.Length)
        {
            if (openOrClose == true)
            {
                trainUnlocked[numTrain] = true;
                Debug.Log("Train: " + numTrain + " unlocked!");
            }
            else
            {
                trainUnlocked[numTrain] = false;
                Debug.Log("Train: " + numTrain + " locked!");
            }
        }
        else
            Debug.LogWarning("Wrong NumberOfTrain! Enterred number: " + numTrain + " Max Train: " + trainUnlocked.Length);
        mainScript.uiScript.CheckUnlockedTrains();
    }
    private void CheckManuValues()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (mainScript.isTrainShopOpen)
                mainScript.uiScript.CheckUnlockedTrains();
            switch (mainScript.uiScript.idMenu)
            {
                case 3:
                    {
                        mainScript.uiScript.CheckTrainUpgrade(mainScript.uiScript.tsScript.tScript);
                        if (mainScript.uiScript.isRepairMenuOpen)
                            mainScript.uiScript.UpdateRepairInfo();
                        else if (mainScript.uiScript.isSellMenuOpen)
                            mainScript.uiScript.UpdateInfoSellMenuTrain();
                        else if (mainScript.uiScript.isWagonBuyMenuOpen)
                            mainScript.uiScript.UpdateWagonBuyMenu();
                        break;
                    }
                case 5:
                    {
                        mainScript.uiScript.pList.CheckPassenger();
                        break;
                    }
                case 6:
                    {
                        mainScript.uiScript.sScript.CheckUpgrade();
                        break;
                    }
            }
        }
    }
    public bool CheckValue(float value, bool isTicket)
    {
        if (isTicket)
        {
            if (value <= newTickets)
                return true;
        }
        else
        {
            if (value <= newMoney)
                return true;
        }
        return false;
    }
    public void StaticMoneyToReward()
    {
        ChangeMoney(gameObject, mainScript.GetStaticReward(), false);
    }
    public void StaticTicketsToReward()
    {
        ChangeTickets(gameObject, mainScript.GetStaticRewardTickets(), false);
    }
    public float GetMoney()
    {
        return newMoney;
    }
    public float GetTickets()
    {
        return newTickets;
    }
    public float GetDifferenceMoney(float value)
    {
        float diff = newMoney - value;
        if (diff >= 0)
            return 0;
        else
            return diff * -1;
    }
    public float GetDifferenceTickets(float value)
    {
        float diff = newTickets - value;
        if (diff >= 0)
            return 0;
        else
            return diff * -1;
    }
    public float GetInfoEarnedMoney()
    {
        return _earnedMoney;
    }
    public float GetInfoEarnedTickets()
    {
        return _earnedTickets;
    }
    public float GetInfoSpentMoney()
    {
        return _spentMoney;
    }
    public float GetInfoSpentTickets()
    {
        return _spentTickets;
    }
    public void SaveData()
    {
        SaveSystem.SavePlayerData(this);
    }
    public void LoadData()
    {
        PlayerDataData data = SaveSystem.LoadPlayerData(this);
        //newMoney = data.Money;
        newTickets = data.Tickets;
    }
    private void OnApplicationPause(bool pause)
    {
        SaveData();
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
}
