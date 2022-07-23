using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject instantiateTempPortal;
    public AudioClip portalClip;
    public void PlayAudioClip(AudioClip clipAudio)
    {
        GetComponent<AudioSource>().PlayOneShot(clipAudio);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y + 20, collision.gameObject.transform.position.z);
            Instantiate(instantiateTempPortal, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z), Quaternion.identity);
            PlayAudioClip(portalClip);
        
        }
    }

    IEnumerator delTempPortalCotoutine()
    {
        yield return new WaitForSeconds(1);
        Destroy(instantiateTempPortal);
        PlayAudioClip (portalClip);

    }
}
