using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static InterstitialAd S;

    [SerializeField] private string _androidUnitId = "Interstitial_Android"; 
    [SerializeField] private string _iOSAdUnitId = "Interstitial_iOS";

    private string _adUnitId;

    void Awake()
    {
        S = this;
      //  InterstitialAd.S.LoadAd();//mb move in another script 
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSAdUnitId
            : _androidUnitId;

        StartCoroutine(loadAdsCoroutine());
    }

    IEnumerator loadAdsCoroutine()
    {
        yield return new WaitForSeconds(5);
        LoadAd();

    }

    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    public void ShowAd()
    {
        Debug.Log("Showing Ad: " + _adUnitId);
        Advertisement.Show(_adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        //successfully loaded content
        Debug.Log("Success!");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        // Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
        Debug.Log("FAIL");//вот тут оно стопорится :с 
        StartCoroutine(loadAdsCoroutine());

    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");//тут тоже поломано, соответственно 
        Debug.Log("ITS FAIL HERE!");//delete it
    }

    public void OnUnityAdsShowStart(string placementId)
    {
       // throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        //click on the advertising.. add some actions (instantiate hero or something else)
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        StartCoroutine(loadAdsCoroutine());
    }

   

    
}
