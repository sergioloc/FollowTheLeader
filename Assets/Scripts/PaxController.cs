using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaxController : MonoBehaviour
{

	public int jumpForce = 0;
	public int initialSpeed = 0;
	public float delay = 0;
	public bool standBy = false;
	
	private Rigidbody2D rb2d;
	private bool isGround;
	private int speed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		isGround = true;
		speed = initialSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !standBy)
        {
			Jump();
		}
		if (!standBy){
			rb2d.transform.Translate(Vector2.right * speed * Time.deltaTime);
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
	
	
	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Virus")
        {
            Destroy(collision.gameObject);
				Destroy(gameObject);
        }
    }
	
	void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SafeZone")
        {
			Destroy(gameObject);
        }
    }
	
    public void Jump(){
        if (isGround)
            StartCoroutine(WaitForJump());
    }

	IEnumerator WaitForJump()
    {
        yield return new WaitForSeconds(delay * 0.1f);
		rb2d.AddForce(Vector2.up * jumpForce * 100);
        rb2d.AddForce(Vector2.right * 200f);
	}
}
