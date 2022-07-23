using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGateScript : MonoBehaviour
{

    public GameObject gate;
    private bool openOrNot;
    private bool isGateOpened;
    public AudioClip plateClip;


    public void PlayAudioClip(AudioClip clipAudio)
    {
        GetComponent<AudioSource>().PlayOneShot(clipAudio);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Ground" && collision.tag != "Bomb" && collision.tag != "Untagged")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
            openOrNot = true;
            PlayAudioClip(plateClip);
            StartCoroutine(stopGateCoroutine());

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Ground" && collision.tag != "Bomb" && collision.tag != "Untagged")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            
        }
    }

    private void Update()
    {
        if (openOrNot && !isGateOpened)
        {
            gate.transform.position = new Vector3 (gate.transform.position.x, gate.transform.position.y + Time.deltaTime, gate.transform.position.z);
        }

        
    }
    IEnumerator stopGateCoroutine()
    {
        yield return new WaitForSeconds(5);
        openOrNot = false;
        isGateOpened = true;
    }
}
