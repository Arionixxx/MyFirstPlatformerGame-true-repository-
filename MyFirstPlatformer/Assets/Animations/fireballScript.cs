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





    // Start is called before the first frame update
    void Start()
    {
        fireTimee = 1;
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
            Destroy(fireball);
            fireTimee = 1;
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
    {
        if (collision.gameObject.tag != "Player")
        {
            Debug.Log("zemlya");
            Destroy(fireball);
        }
       
        
    }

    void FireUpdateRight()
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
