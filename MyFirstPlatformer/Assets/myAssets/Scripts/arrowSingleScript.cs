using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowSingleScript : MonoBehaviour
{

    public float arrowSpeed;
    private Rigidbody2D arrowRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        arrowRigidBody = GetComponent<Rigidbody2D>();
        arrowRigidBody.velocity = transform.up * arrowSpeed;
      //  arrowRigidBody.velocity 
        StartCoroutine(arrowDestroyCoroutine());
    }

    IEnumerator arrowDestroyCoroutine()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        Debug.Log("Arrow destroied");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "ArrowDestr")
        {
            Destroy(gameObject);
        }
    }
}
