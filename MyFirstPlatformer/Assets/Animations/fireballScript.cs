using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballScript : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public int damage;
    public LayerMask whatIsSolid;






    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       if (CharacterMovement.fireForMovementScript.flipX)
        {
              transform.Translate(-Vector2.right * speed *  Time.deltaTime);
            
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
