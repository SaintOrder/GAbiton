using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int JumpPower = 10;

    [SerializeField]
    private float MoveSpeed = 10f;

    private Rigidbody2D _rb;
    private Vector2 _input;

    private BoxCollider2D _groundCheckCollider;
    private GroundCheck _groundCheck;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _groundCheckCollider = GetComponentInChildren<BoxCollider2D>();
        _groundCheck = GetComponentInChildren<GroundCheck>();
    }

    private void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        bool isGrounded = _groundCheck.isGrounded;
        if(_input.x != 0f && isGrounded)
        {
            _rb.AddForce(new Vector2(_input.x * MoveSpeed, 0), ForceMode2D.Impulse);
        }

        if(_input.y > 0 && isGrounded)
        {
            _groundCheck.isGrounded = false;
            _rb.AddForce(new Vector2(0, _input.y * JumpPower), ForceMode2D.Impulse);
        }
    }
}
