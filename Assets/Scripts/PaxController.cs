using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaxController : MonoBehaviour
{

	public int jumpForce = 0;
	public int initialSpeed = 0;
	public float delay = 0;
	public bool standBy = false;
	public bool isLeader = false;
	
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
        if (Input.GetKeyDown(KeyCode.Space) && !standBy && isGround)
        {
			StartCoroutine(Jump(delay));
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
	
	void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SafeZone")
        {
			if (isLeader){
				Debug.Log("Game Over");
			}
			else{
				Destroy(gameObject);
			} 
        }
    }
	
	IEnumerator Jump(float d)
    {
        yield return new WaitForSeconds(d * 0.1f);
		Debug.Log(jumpForce);
		rb2d.AddForce(Vector2.up * jumpForce * 100);
	}
}
