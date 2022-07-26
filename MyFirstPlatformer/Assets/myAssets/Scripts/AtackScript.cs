using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtackScript : MonoBehaviour
{

    public Transform shotPosition;
    public GameObject bullet;
    public AudioClip fireInstantiateClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnAtackButtonClick()
    {
        Instantiate(bullet, shotPosition.transform.position, transform.rotation);
        PlayAudioClip(fireInstantiateClip);
    }

    public void PlayAudioClip(AudioClip clipAudio)
    {
        GetComponent<AudioSource>().PlayOneShot(clipAudio);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(bullet, shotPosition.transform.position, transform.rotation);
            PlayAudioClip(fireInstantiateClip);
        }
    }
}
