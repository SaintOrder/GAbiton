using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementt : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public Transform jumpEnd;
    public float maxSpeed;

    private bool faceRight = true;
    private Animator _anim;
    private Rigidbody2D _rb2d;
    private bool _isWalking;
    private bool _isFacingRight;
    private bool _isGrounded;
    private bool _jump;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {   //check if its grounded
        float h = (Input.GetAxis("Horizontal"));
        _isGrounded = Physics2D.Linecast(transform.position, jumpEnd.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {//check for input and if itsgrounded
            _jump = true;
        }
       
    }


    void FixedUpdate()
    {
        //movement
        float h = (Input.GetAxis("Horizontal"));
        _rb2d.velocity = new Vector2(h * speed, _rb2d.velocity.y);
        //calls animation
        _isWalking = Mathf.Abs(h) > 0;
        _anim.SetBool("IsRunning", _isWalking);
        //make the character face the right direction
        if (h > 0 && !_isFacingRight)
        {
            Flip();
        }
        else if (h < 0 && _isFacingRight)
        {
            Flip();
        }
         
        //jumping
        if (_jump)
        {
            _rb2d.AddForce(new Vector2(_rb2d.velocity.x, jumpPower));
            _jump = false;
        }
    }

    void Flip()
    {
      
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

    }
}
