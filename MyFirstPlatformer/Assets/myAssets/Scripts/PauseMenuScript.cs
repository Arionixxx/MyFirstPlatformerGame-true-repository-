using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isGamePaused = false;

    public void continueButton()
    {
        pauseMenu.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1;
    }

    public void mainMenuButton()
    {
        SceneManager.LoadScene(0);
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                pauseMenu.SetActive(true);
                isGamePaused = true;
                Time.timeScale = 0;
                Debug.Log("pause");
            }
            else
            {
                continueButton();
            }
        }
    }
}
