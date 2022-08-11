using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinPicker : MonoBehaviour
{

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject lvlCompleteText;
    public GameObject controllersUI;
    public GameObject finishPanel;
    public GameObject hpBar;
    public GameObject coinsBar;
    public GameObject pauseBar;


    public TMP_Text finishCoinsText;
    public TMP_Text coinsText;
    public AudioClip clipCoins;
    public AudioClip clipFinish;
    private bool isLvLEnded;



    private float coins = 0;
    void Start()
    {
        
    }

    void Update()
    {
    }
    public void PlayAudioClip(AudioClip clipAudio)
    {
        GetComponent<AudioSource>().PlayOneShot(clipAudio);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(collision.gameObject);
            PlayAudioClip(clipCoins);

        }

        if(collision.gameObject.tag == "Finish")
        {
            lvlCompleteText.SetActive(true);

            if (coins > 0 && coins < 20)
            {
                star1.SetActive(true);
            }
            if (coins >=20 && coins <= 50)
            {
                star1.SetActive(true);
                star2.SetActive(true);
            }
            if (coins > 50)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }
            if (!isLvLEnded)
            {
                PlayAudioClip(clipFinish);
                isLvLEnded = true;
            }
            controllersUI.SetActive(false);
            hpBar.SetActive(false);
            coinsBar.SetActive(false);
            pauseBar.SetActive(false);
            finishPanel.SetActive(true);
            finishCoinsText.text = ($"Coins count: {coins.ToString()}");
            StartCoroutine(lvlEndCoroutine());
            GameAnalyticsScript.instance.OnLevelComplete(SceneManager.GetActiveScene().buildIndex + 0);
        }
 
    }

    IEnumerator lvlEndCoroutine()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);//start menu
    }
}