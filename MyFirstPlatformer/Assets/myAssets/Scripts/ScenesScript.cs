using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesScript : MonoBehaviour
{
   // private bool isGameStarted;
    private int currentLevel = 1;
  
    void Start()
    {
        
    }

    public void StartGame()
    {
       
        {
            SceneManager.LoadScene(currentLevel);
            //to do: change the number of level depending on the current level
            
        }
    }

    public void Options()
    {

    }

    public void Exit()
    {

    }
   
}
