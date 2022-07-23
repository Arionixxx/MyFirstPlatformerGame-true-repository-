using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireScript : MonoBehaviour
{

    public AudioClip fireClip;
    // Start is called before the first frame update
    void Start()
    {
        
            StartCoroutine(spawnFireDestroy());
        
    }
    public void PlayAudioClip(AudioClip clipAudio)
    {
        GetComponent<AudioSource>().PlayOneShot(clipAudio);
    }

    // Update is called once per frame
    IEnumerator spawnFireDestroy()
    {
        PlayAudioClip(fireClip);  
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
