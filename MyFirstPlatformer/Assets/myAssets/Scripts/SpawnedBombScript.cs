using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnedBombScript : MonoBehaviour
{
    // public SpriteRenderer bombSpriteRend;
    public GameObject spawnedFire;

    //написать задержку и анимацию для взрыва
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Ground")
        {

            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(coroutineForFireDestroy());
            StartCoroutine(coroutineForBombDestroy());
            Instantiate(spawnedFire, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        }
    }

    IEnumerator coroutineForBombDestroy()
    {
        yield return new WaitForSeconds(0.16f);
        Destroy(gameObject);
        
    }
    IEnumerator coroutineForFireDestroy()
    {
        yield return new WaitForSeconds(0.15f);
        Destroy(spawnedFire); //почему не работает??
    }
}
