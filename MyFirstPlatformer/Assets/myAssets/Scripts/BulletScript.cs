using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float bulletSpeed;
    private Rigidbody2D bulletRigidbody;
    public AudioClip bulletDestroyClip;

    public void PlayAudioClip(AudioClip clipAudio)
    {
        GetComponent<AudioSource>().PlayOneShot(clipAudio);
    }
    void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = transform.right * bulletSpeed;
        StartCoroutine(bulletDestroyCoroutine());
    }

    IEnumerator bulletDestroyCoroutine()
    {
        yield return new WaitForSeconds(5);
      //  PlayAudioClip(bulletDestroyClip);
        Destroy(this.gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mace" || collision.tag == "Ground")
        {
          //  PlayAudioClip(bulletDestroyClip);
            Destroy(this.gameObject);
            
        }
    }
}
