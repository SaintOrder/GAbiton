using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }
}
