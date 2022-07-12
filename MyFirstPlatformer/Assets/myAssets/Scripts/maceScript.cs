using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maceScript : MonoBehaviour
{
    public GameObject mace;
    public Animator maceAnimator;
    public Vector2 direction;


    void Start()
    {
        mace = GetComponent<GameObject>();
        maceAnimator = GetComponent<Animator>();
        direction = Vector2.right;
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fireball")
        {
            maceAnimator.SetTrigger("maceDie");
        }

        if (collision.gameObject.tag == "Reverse")
        {
            Debug.Log("reverse!");
            direction = -direction;
        }
    }

}

