using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapPlateScript : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Ground")
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y - 0.1f, transform.position.z);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Ground")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
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
