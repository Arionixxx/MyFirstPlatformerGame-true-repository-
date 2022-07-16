using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapPlateScript : MonoBehaviour
{
    public GameObject bomb;
  //  private bool isBombSpawned;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Ground" && collision.tag != "Bomb")
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y - 0.1f, transform.position.z);
           // if (!isBombSpawned)
            {
                Instantiate(bomb, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), Quaternion.identity);
               // isBombSpawned = true;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Ground" && collision.tag!= "Bomb")
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
