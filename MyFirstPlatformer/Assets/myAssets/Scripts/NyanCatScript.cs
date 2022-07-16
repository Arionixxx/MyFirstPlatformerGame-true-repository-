using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyanCatScript : MonoBehaviour
{
    public GameObject nyanCat;
    public GameObject QuestionSymbol;
  
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        {

           
            nyanCat.SetActive(true);
            QuestionSymbol.SetActive(false);
            
            
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
