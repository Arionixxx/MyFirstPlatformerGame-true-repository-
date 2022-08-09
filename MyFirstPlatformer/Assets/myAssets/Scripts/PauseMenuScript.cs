using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isGamePaused = false;

    public bool isSensoryPauseActive;

    public void OnSensoryPauseClick()
    {
        isSensoryPauseActive = true;
    }
    public void continueButton()
    {
        pauseMenu.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1;
    }

    public void mainMenuButton()
    {
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }


    IEnumerator adsCoroutine()
    {
        yield return new WaitForSeconds(3);
        InterstitialAd.S.ShowAd();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || isSensoryPauseActive)
        {
            if (!isGamePaused)
            {
                 InterstitialAd.S.ShowAd();
               // StartCoroutine(adsCoroutine());
                pauseMenu.SetActive(true);
                isGamePaused = true;
                Time.timeScale = 0;
                Debug.Log("pause");
                isSensoryPauseActive = false;
            }
            else
            {
                continueButton();
            }
        }
    }
}
