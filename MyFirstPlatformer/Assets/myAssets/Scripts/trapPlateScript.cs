using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapPlateScript : MonoBehaviour
{
    public GameObject bomb;
    public AudioClip panelClip;
    //  private bool isBombSpawned;

    public void PlayAudioClip(AudioClip clipAudio)
    {
        GetComponent<AudioSource>().PlayOneShot(clipAudio);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Ground" && collision.tag != "Bomb" && collision.tag != "Untagged" && collision.tag == "Player")
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y - 0.1f, transform.position.z);
           
            {
                Instantiate(bomb, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), Quaternion.identity);
                PlayAudioClip(panelClip);
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Ground" && collision.tag!= "Bomb" && collision.tag != "Untagged" && collision.tag == "Player")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
          //  isBombSpawned = false;
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
