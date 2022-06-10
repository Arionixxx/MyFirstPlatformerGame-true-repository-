using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maceScript : MonoBehaviour
{
    public GameObject mace;
    public Animator maceAnimator;


    void Start()
    {
        mace = GetComponent<GameObject>();
        maceAnimator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fireball")
        {
            maceAnimator.SetTrigger("maceDie");
        }
    }

}

