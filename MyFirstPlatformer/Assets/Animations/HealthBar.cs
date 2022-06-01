using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;
    public float fill;
    public GameObject fire;
    public bool damageInFire = false;
   // public GameObject player;
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        fill = 1f;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (damageInFire == true)
        {
            fill -= Time.deltaTime * 0.05f;
        }
        bar.fillAmount = fill;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            damageInFire = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Fire")
        {
            damageInFire = false;
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
