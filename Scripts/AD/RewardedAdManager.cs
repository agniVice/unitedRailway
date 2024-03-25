using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardedAdManager : MonoBehaviour
{

    public static RewardedAdManager S;
    private TimerScript timerScript;

    [SerializeField] private Image _imageOfReward;
    [SerializeField] private Sprite[] _spriteOfReward;

    public string RewardType;
    private void Awake()
    {
        S = this;
    }
    public void Start()
    {
        timerScript = FindObjectOfType<TimerScript>();

    }
    public void SetRewardAndShowAd(string rewardType)
    {
        RewardType = rewardType;
        RewardedAds.S.ShowAd();
    }
    public void UpdateReward()
    {
        float i = Random.Range(0, 100);
        if (i > 80)
        {
            RewardType = "RewardStaticTickets";
            _imageOfReward.sprite = _spriteOfReward[2];
            return;
        }
        if (i > 40)
        {
            RewardType = "RewardStaticMoney";
            _imageOfReward.sprite = _spriteOfReward[1];
            return;
        }
        if (i > 0)
        {
            RewardType = "RewardStaticMoney";
            _imageOfReward.sprite = _spriteOfReward[0];
            return;
        }
    }
}
