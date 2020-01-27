using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    Rigidbody2D body;
    private bool faceRight = true;
    float horizontal;
    float vertical;
    public float moveLimiter = .6f;
    public float moveSpeed = 7.5f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        if (horizontal > 0 && !faceRight)
        {
            flip();
        }

        else if (horizontal < 0 && faceRight)
        {
            flip();
        }
    }
    void flip ()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    void FixedUpdate()
    {
        //Check if character is moving diaginally
        if (horizontal != 0 && vertical != 0)
        {
            //Average out speed for simultaneous inputs.
            body.velocity = new Vector2((horizontal * moveSpeed) * moveLimiter, (vertical * moveSpeed) * moveLimiter);
        }
        else
        {
            body.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
        }

        
    }
}
