using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterScript : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Ground" && collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
