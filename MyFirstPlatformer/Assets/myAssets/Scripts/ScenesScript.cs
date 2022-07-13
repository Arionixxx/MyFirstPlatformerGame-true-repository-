using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesScript : MonoBehaviour
{
    private bool isGameStarted;
  
    void Start()
    {
        
    }

    public void StartGame()
    {
        if (!isGameStarted)
        {
            SceneManager.LoadScene(1);
            isGameStarted = true;
        }
    }
   
}
