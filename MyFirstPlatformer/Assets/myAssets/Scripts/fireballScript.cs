using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballScript : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public int damage;
    public LayerMask whatIsSolid;
    public GameObject fireball;
    private float fireTimee;
    private Animator animator;
    public float kd;
    public float kdCol;
    private float maceDieDelay;
    public GameObject maceEnemy;
    private Animator maceEnemyAnimator;
    private Vector3 tempMacePos;
    private Rigidbody2D maceRigid;
    public GameObject spawnMaceAfterDie;





    // Start is called before the first frame update
    void Start()
    {
        maceRigid = maceEnemy.GetComponent<Rigidbody2D>();
        maceDieDelay = 1;
        fireTimee = 0.8f;
        kd = 0.2f;
        kdCol = 0.2f;
        animator = GetComponent<Animator>();
        maceEnemyAnimator = maceEnemy.GetComponent<Animator>();
        maceEnemyAnimator.SetTrigger("maceDie");
    }

    void Update()
    {
        if (fireTimee > 0)
        {
            fireTimee -= Time.deltaTime;
        }
        else
        {
            animator.SetTrigger("fireDestroy");
            if (kd > 0)
            {
                kd -= Time.deltaTime;
            }
            else
            {
                Destroy(fireball);//
                
                Debug.Log("destroyed!");//
                fireTimee = 0.8f;
                kd = 0.2f;
            }
        }

        {

               if (CharacterMovement.fireForMovementScript.flipX)
            {

                Debug.Log("Fireball!!");
                transform.Translate(-Vector2.right * speed *  Time.deltaTime);

            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            
            animator.SetTrigger("fireDestroy");
            {
                Debug.Log("zemlya");
                Destroy(fireball);

        if (collision.gameObject.tag == "Mace")
                {

                        tempMacePos = collision.gameObject.transform.position;
                        Destroy(collision.gameObject);
                        Instantiate(spawnMaceAfterDie, new Vector3(tempMacePos.x, tempMacePos.y, -1), Quaternion.identity);
                    
                }

            }

        }
       
        
    }

    void FireUpdateRight()//don`t use
    {
        float fireTime = 30;
        while (fireTime > 0)
        {
            transform.Translate(-Vector2.right * speed * Time.deltaTime);
            fireTime -= 0.1f * Time.deltaTime;
        }
    }

    void FireUpdateLeft()
    {
        float fireTime = 30;
        while (fireTime > 0)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            fireTime -= 0.1f * Time.deltaTime;
        }
    }
}
