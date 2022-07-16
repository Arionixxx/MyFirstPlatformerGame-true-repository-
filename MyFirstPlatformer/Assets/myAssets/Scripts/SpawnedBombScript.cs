using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedBombScript : MonoBehaviour
{

    //написать задержку и анимацию для взрыва
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Ground")
        {
            //destroy anim
        }
    }
}
