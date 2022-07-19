using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Vector3 _groundCheckOffset;
    private Vector3 _input;
    private Vector3 _swimDirection;
    private bool _isMoving;
    private bool _isGrounded;
    private bool _isFlying;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D _rigidbody;
    private CharactersAnimations _animations;
    [SerializeField] private SpriteRenderer _characterSprite;
    [SerializeField] private SpriteRenderer _fireballSprite;
    public static SpriteRenderer fireForMovementScript;

    public GameObject fireball;
    private Vector2 _fireballMove;
    private float TimeBtwSFireballs;
    public float startTimeBtwFireballs;
    private float timeDestroyFireball;
    public float startTimeDestroyFireball;

    private bool isWater;
    private bool isMoveRight;
    private bool isRotated;

    public Transform checkGroundLeft;
    public Transform checkGroundRight;
    public Transform checkGroundMiddle;


    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animations = GetComponentInChildren<CharactersAnimations>();
        timeDestroyFireball = startTimeDestroyFireball;
        _speed = 5;
        _jumpForce = 5.5f;
        _swimDirection = Vector3.up;
        
    }

    // Update is called once per frame
  private void FixedUpdate()
    {
        
        fireForMovementScript = _fireballSprite;
        Move();
        CheckGround();
        if (Input.GetKey(KeyCode.Space) && !isWater)
        {
            if (_isGrounded)
            {
                Jump();
                _animations.Jump();
            }
        }

        if (Input.GetKey(KeyCode.Space) && isWater)
        {
            _rigidbody.gravityScale = 0;
            Swim();
            
        }

        if (Input.GetKeyUp(KeyCode.Space) && isWater)
        {
            _rigidbody.gravityScale = 0.8f;
        }

        if (TimeBtwSFireballs <= 0)
        {
            if (Input.GetKey(KeyCode.F))
            {
                _fireballSprite.flipX = _characterSprite.flipX;
                Atack();
                TimeBtwSFireballs = startTimeBtwFireballs;
                


            }
        }
        else
        {
            TimeBtwSFireballs -= Time.deltaTime;
        }
       
        
        _animations.IsMoving = _isMoving;
        _animations.IsFlying = IsFlying();
    }
    private void Move()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += _input * _speed * Time.deltaTime;
        _isMoving = _input.x != 0 ? true : false;
     
        if (_isMoving)
        {
            isMoveRight = _input.x > 0? false: true;

            // _characterSprite.flipX = _input.x > 0 ? false : true;
            if (isMoveRight && !isRotated)
            {
                isRotated = true;
                _characterSprite.transform.Rotate(0, 180, 0);
            }

            if (!isMoveRight && isRotated)
            {
                isRotated = false;
                _characterSprite.transform.Rotate(0, 180, 0);
            }
        }
       
    }

    private void Swim()
    {
        
         transform.position += _swimDirection * _jumpForce * Time.deltaTime;
    }

    private void Atack()
    {
        //Instantiate(fireball, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity);
        Instantiate(fireball, new Vector3(transform.position.x, transform.position.y, -1), transform.rotation);



    }

    private void Jump()
    {
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    

    private void CheckGround()
    {
        float rayLength = 0.3f;
        Vector3 rayStartPositionLeft = checkGroundLeft.transform.position + _groundCheckOffset;
        RaycastHit2D hitLeft = Physics2D.Raycast(rayStartPositionLeft, transform.TransformDirection(Vector3.down), rayLength, groundMask);
        Vector3 rayStartPositionRight = checkGroundRight.transform.position + _groundCheckOffset;
        RaycastHit2D hitRight = Physics2D.Raycast(rayStartPositionRight, transform.TransformDirection(Vector3.down), rayLength, groundMask);
        Vector3 rayStartPositionMiddle = checkGroundMiddle.transform.position + _groundCheckOffset;
        RaycastHit2D hitMiddle = Physics2D.Raycast(rayStartPositionMiddle, transform.TransformDirection(Vector3.down), rayLength, groundMask);

        if (hitLeft.collider != null  || hitRight.collider != null)
        {
            _isGrounded =  hitLeft.collider.CompareTag("Ground") || hitRight.collider.CompareTag("Ground");
         
        }
        else
        {
             _isGrounded = false; 
            
        }
            
    }
    private bool IsFlying()
    {
        if (_rigidbody.velocity.y < 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "swimWater")
        {
            _speed = 2.5f;
            _rigidbody.gravityScale = 0.8f;
            _jumpForce = 5;
            isWater = true;
            Debug.Log("it`s water");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "swimWater")
        {
            _speed = 5;
            _rigidbody.gravityScale = 1.6f;
            _jumpForce = 5.5f;
            isWater = false;
            Debug.Log("it`s NOT water");
        }
    }

    
}
