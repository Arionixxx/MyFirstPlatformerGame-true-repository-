using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string _AndroidGameID;
    [SerializeField] private string _IOSGameID;
    [SerializeField] private bool _testMode;

    private string _gameId;

    public static bool isAdvertisementInitialized;

    private void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
         _gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _IOSGameID
            : _AndroidGameID;

        Advertisement.Initialize(_gameId, _testMode, this); 
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete. ");
        InterstitialAd.S.LoadAd();//test
        isAdvertisementInitialized = true;
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads initialization failed: {error.ToString()} - {message}");
        isAdvertisementInitialized = false;
    }
}
