using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using Unity.Services.Analytics;
using Unity.Services.Core;

public class UnityAnalytics : MonoBehaviour
{
    private void Awake()
    {
        StartAnatylics();
    }
    async void StartAnatylics()
    {
        try
        {
            await UnityServices.InitializeAsync();
            List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
        }
        catch (ConsentCheckException e)
        {
            Debug.Log(e);
            // Something went wrong when checking the GeoIP, check the e.Reason and handle appropriately.
        }
    }
    public void OnEventCompleted(string eventName)
    {
        AnalyticsService.Instance.CustomData(eventName);
    }
    public void OnMissionSuccess(int missionId)
    {
        Dictionary<string, object> parameters = new Dictionary<string, object>() //Define the parameters first
        {
            {"missionId", missionId}
        };
        AnalyticsService.Instance.CustomData("missionSuccess", parameters);
    }
    public void OnRewardedAdSuccess(int missionId)
    {
        AnalyticsService.Instance.CustomData("rewardedAdSuccess", new Dictionary<string, object>
        {
            {"missionId", missionId}
        });
        Debug.Log("RewardedSuccess");
    }
}
