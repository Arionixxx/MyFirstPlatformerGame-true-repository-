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
        RewardedAds.S.ShowAd();
      //  PlayAudioClip(dieMessClip);
        StartCoroutine(RestartLevel());
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
