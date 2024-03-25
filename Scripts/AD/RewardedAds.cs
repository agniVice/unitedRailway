using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static RewardedAds S;

    private MainSceneScript mainScript;
    private UnityAnalytics unityAnalytics;
    private PlayerData playerData;
    private UITween uiTween;
    private RewardedAdManager rewardedAdManager;

    [SerializeField] private string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] private string _iOSAdUnitId = "Rewarded_iOS";
    private string _rewardType;
    public GameObject _canvasAdIsNotReady;

    private string _adUnitId;

    void Awake()
    {
        S = this;
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSAdUnitId
            : _androidAdUnitId;

        mainScript = FindObjectOfType<MainSceneScript>();
        unityAnalytics = FindObjectOfType<UnityAnalytics>();
        playerData = FindObjectOfType<PlayerData>();
        uiTween = FindObjectOfType<UITween>();
        rewardedAdManager = FindObjectOfType<RewardedAdManager>();
        rewardedAdManager.UpdateReward();

        uiTween.HideRewardButton();

    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    public void ShowAd()
    {
        // Then show the ad:
        _rewardType = rewardedAdManager.RewardType;
        Advertisement.Show(_adUnitId, this);
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            switch (_rewardType)
            {
                case "RewardStaticMoney":
                    {
                        Debug.Log("Unity Ads Rewarded Ad Completed");
                        playerData.StaticMoneyToReward();
                        mainScript.uiScript.RewardedAdWasShowed(true);
                        break;
                    }
                case "RewardStaticTickets":
                    {
                        Debug.Log("Unity Ads Rewarded Ad Completed");
                        playerData.StaticTicketsToReward();
                        mainScript.uiScript.RewardedAdWasShowed(false);
                        break;
                    }
                case "PassengerUpgrade":
                    {
                        Debug.Log("Unity Ads Rewarded Ad Completed");
                        FindObjectOfType<PriceListScript>().UpgradePassenger(true);
                        break;
                    }
                case "ExtraContinue":
                    {
                        Debug.Log("Unity Ads Rewarded Ad Completed");
                        mainScript.ExtraAdContinue();
                        break;

                    }
                case "NoMoneyReward":
                    {
                        Debug.Log("Unity Ads Rewarded Ad Completed");
                        playerData.StaticMoneyToReward();
                        FindObjectOfType<UITween>().CloseNoMoney();
                        mainScript.uiScript.RewardedAdWasShowed(true);
                        break;
                    }
            }
            _rewardType = null;
            unityAnalytics.OnRewardedAdSuccess(mainScript.GetMissionID());
            Advertisement.Load(_adUnitId, this);
            uiTween.HideRewardButton();
            rewardedAdManager.UpdateReward();
        }
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
        uiTween.ShowRewardButton();
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        _canvasAdIsNotReady.SetActive(true);
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        _canvasAdIsNotReady.SetActive(true);
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }
}