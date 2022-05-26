using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Vector3 _groundCheckOffset;
    private Vector3 _input;
    private bool _isMoving;
    private bool _isGrounded;
    private bool _isFlying;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D _rigidbody;
    private CharactersAnimations _animations;
    [SerializeField] private SpriteRenderer _characterSprite;
    // Start is called before the first frame update
   private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animations = GetComponentInChildren<CharactersAnimations>();
    }

    // Update is called once per frame
  private void Update()
    {
        Move();
        CheckGround();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isGrounded)
            {
                Jump();
                _animations.Jump();
            }
        }

        _animations.IsMoving = _isMoving;
        _animations.IsFlying = IsFlying();
    }
    private void Move()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += _input * _speed * Time.deltaTime;
        _isMoving = _input.x != 0 ? true : false;
       // Debug.Log(_speed);
        if (_isMoving)
        {
            _characterSprite.flipX = _input.x > 0 ? false : true;
        }
       // _animations.IsMoving = _isMoving;
    }
    private void Jump()
    {
      //  Debug.Log("Jump!");
        _rigidbody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        float rayLength = 0.3f;
        Vector3 rayStartPosition = transform.position + _groundCheckOffset;
        RaycastHit2D hit = Physics2D.Raycast(rayStartPosition, transform.TransformDirection(Vector3.down), rayLength, groundMask);

        if (hit.collider != null)
        
       // if (true) сюда даже не заходит
        {
            _isGrounded = hit.collider.CompareTag("Ground");
          //  Debug.Log("something under you!");
         //   Debug.Log(hit.collider);
         
        }
        else
        {
            _isGrounded = false; //or true??
         //   Debug.Log("It's not ground under you! It's not underground!!!");
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
}
