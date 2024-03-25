using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private MainSceneScript mainScript;
    public float timeOfLevel;
    public float currentTimer;
    public bool isStopped = false;
    private bool isAdWasShowed = false;
    private void Awake()
    {
        GetTimeOfLevel();
    }
    private void GetTimeOfLevel()
    {
        timeOfLevel = mainScript.timeOfLevel;
    }
    private void Update()
    {
        if (!mainScript.isGamePaused)
        {
            if (!isStopped)
            {
                if (currentTimer >= timeOfLevel)
                {
                    currentTimer = timeOfLevel;
                    mainScript.GameOver("Fail");
                    isStopped = true;
                    return;
                }
                if (isAdWasShowed == false)
                {
                    if (2 >= timeOfLevel / currentTimer)
                    {
                        RewardedAdManager.S.RewardType = "";
                        RewardedAds.S.ShowAd();
                        isAdWasShowed = true;
                    }
                }
                currentTimer += Time.deltaTime;
            }
        }
    }
}
