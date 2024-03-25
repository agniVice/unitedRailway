using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    private string _gameId = "yourID";

    private void Start()
    {
        Advertisement.Initialize(_gameId);
    }
    public static void ShowAdVideo(string placementId)
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Show(placementId);
        }
        else
        {
            Debug.Log("Ad not ready!");
        }
    }

    public void OnInitializationComplete()
    {
        throw new System.NotImplementedException();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        throw new System.NotImplementedException();
    }
}
