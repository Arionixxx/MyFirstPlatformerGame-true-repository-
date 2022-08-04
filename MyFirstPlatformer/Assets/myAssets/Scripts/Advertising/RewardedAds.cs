using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static RewardedAds S;

    [SerializeField] private string _androidUnitId = "Rewarded_Android";
    [SerializeField] private string _iOSAdUnitId = "Rewarded_iOS";

    [SerializeField] private GameObject playerHero;

    private string _adUnitId;

    void Awake()
    {
        S = this;
        //  InterstitialAd.S.LoadAd();//mb move in another script 
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOSAdUnitId
            : _androidUnitId;
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
         Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
        StartCoroutine(RestartLevel());
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        //click on the advertising.. add some actions (instantiate hero or something else)
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        // LoadAd();
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
       // if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.SKIPPED))
        {
            Debug.Log("Unity ads rewarded ad completed. ");
            playerHero.SetActive(true);
            HealthBar.fill = 1f;
            HealthBar.isHeroDie = false;
           // HealthBar.invincibility = false;
            //добавить действие с наградой 
            //
            Advertisement.Load(_adUnitId, this);
        } else
        {
            Debug.Log("Do reload");
        }
    }

    IEnumerator RestartLevel()
    {

        yield return new WaitForSeconds(3);
        //SceneManager.LoadScene("SampleScene");
        //  Debug.Log("you die!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

}
