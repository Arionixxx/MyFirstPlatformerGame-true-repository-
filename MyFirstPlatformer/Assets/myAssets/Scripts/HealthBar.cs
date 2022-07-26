using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image bar;
    public float fill;
    public GameObject fire;
    public bool damageInFire = false;
    public GameObject healthPotion;
    private Rigidbody2D _rigidbody;
    private bool globalDamage;
    public GameObject player;
    public GameObject dieTextMessage;

    private Animator playerAnimator;

    public AudioClip damageAudioClip;
    public AudioClip dieMessClip;
    public AudioClip hpBottleClip;
    public GameObject fireDamageAudio;

    public bool isHeroDie;

    IEnumerator RestartLevel()
    {
        PlayAudioClip(dieMessClip);
        yield return new WaitForSeconds(3);
        //SceneManager.LoadScene("SampleScene");
      //  Debug.Log("you die!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void PlayAudioClip(AudioClip clipAudio)
    {
        GetComponent<AudioSource>().PlayOneShot(clipAudio);
    }
    
    void Start()
    {
        fill = 1f;
        _rigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        globalDamage = false;
        isHeroDie = false;
        
    }

    void Update()
    {   
        
        if (damageInFire == true)
        {
            fill -= Time.deltaTime * 0.05f;
            
        }
        bar.fillAmount = fill;

        if (fill <= 0 && !isHeroDie)
        {
            dieTextMessage.SetActive(true);
            isHeroDie = true;
            StartCoroutine(RestartLevel());
            RestartLevel();
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            damageInFire = true;
            fireDamageAudio.SetActive(true);
          //  globalDamage = true;
            playerAnimator.SetTrigger("globalDamageTrigger");
           // PlayAudioClip(damageAudioClip);
        }
        if (collision.tag == "healthPotion")
        {
            Destroy(collision.gameObject);
            
            fill = 1f;
            PlayAudioClip (hpBottleClip);
        }

        if (collision.tag == "Mace")
        {
            // globalDamage = true;
            PlayAudioClip(damageAudioClip);
            playerAnimator.SetTrigger("globalDamageTrigger");
            
        }

        if (collision.tag == "Water")
        {
            fill = 0;
        }

        if (collision.tag == "Bomb")
        {
            fill -= 0.3f;
            PlayAudioClip(damageAudioClip);
        }

        if (collision.tag == "Arrow")
        {
            fill -= 0.2f;
            PlayAudioClip(damageAudioClip);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            damageInFire = false;
            fireDamageAudio.SetActive(false);
            //  globalDamage = false;
            playerAnimator.SetTrigger("globalNOTDamageTrigger");
        }
        if (collision.tag == "Mace")
        {
           // globalDamage = false;
            playerAnimator.SetTrigger("globalNOTDamageTrigger");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)//Mace hit player
    {
        if (collision.tag == "Mace")
        {
           // Debug.Log("Mace!");
           // PlayAudioClip(damageAudioClip);
            fill -= Time.deltaTime * 0.2f;
            _rigidbody.AddForce(transform.up * 0.25f, ForceMode2D.Impulse);
            _rigidbody.AddForce(-transform.right * 0.05f, ForceMode2D.Impulse);
        }
        
        if (collision.tag == "Fire")
        {
            // PlayAudioClip(damageAudioClip);
            playerAnimator.SetTrigger("globalDamageTrigger");
        }

    }

    
}
