using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvlRestartScript : MonoBehaviour
{
    public AudioClip dieMessClip;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("die!");
      //  InterstitialAd.S.ShowAd();
       // RewardedAds.S.ShowAd();
        StartCoroutine(StartRewardedAds());
        //  PlayAudioClip(dieMessClip);
        // if (!AdsInitializer.isAdvertisementInitialized && !RewardedAds.isRewardAdvertisementAvailible)
        if (!AdsInitializer.isAdvertisementInitialized)
         {
              StartCoroutine(RestartLevel());
        }
    }

    public void PlayAudioClip(AudioClip clipAudio)
    {
        GetComponent<AudioSource>().PlayOneShot(clipAudio);
    }
    IEnumerator RestartLevel()
    {
       
        yield return new WaitForSeconds(3);
        //SceneManager.LoadScene("SampleScene");
        //  Debug.Log("you die!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    IEnumerator StartRewardedAds()
    {
        yield return new WaitForSeconds(1.5f);
        RewardedAds.S.ShowAd();


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
