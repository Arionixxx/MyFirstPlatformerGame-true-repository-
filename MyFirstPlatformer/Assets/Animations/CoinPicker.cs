using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinPicker : MonoBehaviour
{
    public TMP_Text coinsText;
    
    private float coins = 0;
    void Start()
    {
        // text = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        // text.text = Coin.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            coins++;
            coinsText.text = coins.ToString();
            Destroy(collision.gameObject);

        }
    }
}