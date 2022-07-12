using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyanCatScript : MonoBehaviour
{
    public GameObject nyanCat;
    public GameObject QuestionSymbol;
    public GameObject silhouetteCat;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        {

           
            nyanCat.SetActive(true);
            QuestionSymbol.SetActive(false);
            silhouetteCat.SetActive(false);
            Debug.Log("aboba");

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
