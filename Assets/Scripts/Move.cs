using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float speed;
	public float jump;
	public GameObject rayOrigin;
	public float rayCheckDistance;
	Rigidbody2D rb;

    float horizontal;
    private bool faceRight = true;

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        if (horizontal > 0 && !faceRight)
        {
            flip();
        }

        else if (horizontal < 0 && faceRight)
        {
            flip();
        }
    }

    void Start () {
		rb = GetComponent <Rigidbody2D> ();
	}

    void flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    void FixedUpdate () {
		float x = Input.GetAxis ("Horizontal");
		if (Input.GetAxis ("Jump") > 0) {
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin.transform.position, Vector2.down, rayCheckDistance);
			if (hit.collider != null) {
				rb.AddForce (Vector2.up * jump, ForceMode2D.Impulse);
			}
		}
		rb.velocity = new Vector3 (x * speed, rb.velocity.y, 0);

	}
}