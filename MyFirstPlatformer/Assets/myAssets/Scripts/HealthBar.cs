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

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(3);
        //SceneManager.LoadScene("SampleScene");
        Debug.Log("you die!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    void Start()
    {
        fill = 1f;
        _rigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        globalDamage = false;
        
    }

    void Update()
    {   
        
        if (damageInFire == true)
        {
            fill -= Time.deltaTime * 0.05f;
        }
        bar.fillAmount = fill;

        if (fill <= 0)
        {
            dieTextMessage.SetActive(true);
            StartCoroutine(RestartLevel());
            RestartLevel();
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            damageInFire = true;
          //  globalDamage = true;
            playerAnimator.SetTrigger("globalDamageTrigger");
        }
        if (collision.tag == "healthPotion")
        {
            Destroy(collision.gameObject);
            
            fill = 1f;
        }

        if (collision.tag == "Mace")
        {
           // globalDamage = true;
            playerAnimator.SetTrigger("globalDamageTrigger");
        }

        if (collision.tag == "Water")
        {
            fill = 0;
        }

        if (collision.tag == "Bomb")
        {
            fill -= 0.3f;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            damageInFire = false;
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
            Debug.Log("Mace!");
            fill -= Time.deltaTime * 0.2f;
            _rigidbody.AddForce(transform.up * 0.25f, ForceMode2D.Impulse);
            _rigidbody.AddForce(-transform.right * 0.05f, ForceMode2D.Impulse);
        }
    }

    
}
