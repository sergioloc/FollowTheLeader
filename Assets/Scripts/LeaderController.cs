using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderController : MonoBehaviour
{
    
	public int jumpForce = 0;
	public int speed = 0;	
	public GameObject projectile;
	public Transform shotPoint;
	private Rigidbody2D rb2d;
	private bool isGround;
    private float push = 200f;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;
	
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		isGround = true;

        if (GameValues.difficulty == 1){ //observer
            speed = 10;
        }
        else if (GameValues.difficulty == 2){ //baby
            speed = 15;
            rb2d.gravityScale = 6;
        }
        else if (GameValues.difficulty == 3){ //full
            speed = 18;
            rb2d.gravityScale = 6;
        }
        else if (GameValues.difficulty == 4){ //alumni
            speed = 22;
            jumpForce = 18;
            rb2d.gravityScale = 7;
        }
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
        rb2d.transform.Translate(Vector2.right * speed * Time.deltaTime);
		
		if (Input.GetKeyDown(KeyCode.Space))
        {
			Jump();
		}
		
		if (Input.GetKeyDown(KeyCode.A))
        {
			Instantiate(projectile, shotPoint.position, shotPoint.rotation);
		}
		
    }

    public void Jump(){
        if(isGround){
            rb2d.AddForce(Vector2.up * jumpForce * 100);
            rb2d.AddForce(Vector2.right * push);
        }
    }

	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        else if (collision.gameObject.tag == "Virus")
        {
            Debug.Log("Game Over");
        }
    }
	
	void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
        else if (collision.gameObject.tag == "SafeZone")
        {
			Debug.Log("Game Over");
        }
    }
}
