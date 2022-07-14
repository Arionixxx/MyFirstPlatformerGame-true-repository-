using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maceScript : MonoBehaviour
{
    public GameObject mace;
    public Animator maceAnimator;
    public Vector2 direction;
    public Vector3 tempMacePos;
    public GameObject spawnMaceAfterDie;


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
        if (collision.gameObject.tag == "fireball" || collision.gameObject.tag == "Bullet")
        {
            maceAnimator.SetTrigger("maceDie");
            tempMacePos = collision.gameObject.transform.position;
           
            Destroy(this.gameObject);
            Instantiate(spawnMaceAfterDie, new Vector3(tempMacePos.x, tempMacePos.y, -1), Quaternion.identity);
        }

        if (collision.gameObject.tag == "Reverse")
        {
            Debug.Log("reverse!");
            direction = -direction;
        }

        
    }

}

