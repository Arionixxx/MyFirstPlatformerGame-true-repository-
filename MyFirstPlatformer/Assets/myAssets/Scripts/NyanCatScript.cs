using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyanCatScript : MonoBehaviour
{
    public GameObject nyanCat;
    public GameObject QuestionSymbol;
    public AudioClip catMyau;
  
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        {

           
            nyanCat.SetActive(true);
            QuestionSymbol.SetActive(false);
            PlayAudioClip(catMyau);
            
            
        }
    }
    public void PlayAudioClip(AudioClip clipAudio)
    {
        GetComponent<AudioSource>().PlayOneShot(clipAudio);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
