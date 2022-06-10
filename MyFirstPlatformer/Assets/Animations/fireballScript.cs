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
        // StartCoroutine(OnTriggerEnter2D());
        maceEnemyAnimator.SetTrigger("maceDie");
    }

    // Update is called once per frame
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
        //if (Input.GetKey(KeyCode.F))
        {

           // transform.Translate(CharacterMovement.fireForMovementScript.transform.right * speed * Time.deltaTime); // должно работать но с РАЙТ проблемки
            if (CharacterMovement.fireForMovementScript.flipX)
           // if (false)
            {

                Debug.Log("Fireball!!");
                transform.Translate(-Vector2.right * speed *  Time.deltaTime);

               // FireUpdateRight();

            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                //FireUpdateLeft();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
   // IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            
            animator.SetTrigger("fireDestroy");
         //   if (kdCol > 0)
            {
          //      kdCol -= 100 * Time.deltaTime;//ne pashet((
            }
         //   else
            {
                Debug.Log("zemlya");
                Destroy(fireball);

        if (collision.gameObject.tag == "Mace")
                {
                   // maceEnemyAnimator.SetTrigger("maceDie");
                   // Debug.Log("mace!!! blin mace!!!");
                    
                    
                    {
                        // yield return new WaitForSeconds(5);
                        tempMacePos = collision.gameObject.transform.position;
                           // maceRigid.AddForce(transform.up * 0.25f, ForceMode2D.Impulse);//ne rabotaet
                           // Debug.Log("5 sec");

                         Destroy(collision.gameObject);//delete coments
                        Instantiate(spawnMaceAfterDie, new Vector3(tempMacePos.x, tempMacePos.y, -1), Quaternion.identity);

                        // maceDieDelay = 1;


                    }
                }
             //   kdCol = 0.002f;

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
