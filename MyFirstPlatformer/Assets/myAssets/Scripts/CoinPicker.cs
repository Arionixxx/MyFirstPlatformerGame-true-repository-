using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinPicker : MonoBehaviour
{

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject lvlCompleteText;

    public TMP_Text coinsText;
    
    private float coins = 0;
    void Start()
    {
        
    }

    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(collision.gameObject);

        }

        if(collision.gameObject.tag == "Finish")
        {
            lvlCompleteText.SetActive(true);

            if (coins > 0 && coins < 20)
            {
                star1.SetActive(true);
            }
            if (coins >=20 && coins <= 50)
            {
                star1.SetActive(true);
                star2.SetActive(true);
            }
            if (coins > 50)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }
            StartCoroutine(lvlEndCoroutine());
        }
 
    }

    IEnumerator lvlEndCoroutine()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene(0);//start menu
    }
}