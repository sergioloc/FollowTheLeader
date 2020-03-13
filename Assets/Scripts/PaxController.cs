using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaxController : MonoBehaviour
{

	public int jumpForce = 0;
	public int speed = 0;
	
	private Rigidbody2D rb2d;
	private bool isGround;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		isGround = true;
    }

    void Update()
    {
		rb2d.transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
			rb2d.AddForce(Vector2.up * jumpForce * 100);
		}
    }
	
	void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
	
	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "Ground")
        {
            isGround = false;
        }
	}
}
