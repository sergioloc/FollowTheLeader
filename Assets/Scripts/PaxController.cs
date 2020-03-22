using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaxController : MonoBehaviour
{

	public int jumpForce = 0;
	public int speed = 10;
	public float delay = 0;
	public bool standBy = true;
    public bool initialGroup = true;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;
    private bool isJumping;
	
	private Rigidbody2D rb2d;

    void Start()
    {
        isJumping = false;
        rb2d = GetComponent<Rigidbody2D>();
		SetDifficulty();
        if (initialGroup)
            StartCoroutine(StartRunning());

    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && !standBy)
        {
			Jump();
		}
		if (!standBy){
			rb2d.transform.Translate(Vector2.right * speed * Time.deltaTime);
		}	
    }
	
	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ShadowAttack")
        {
            GameValues.numPax--;
			Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "DeadZone")
        {
            GameValues.numPax--;
           Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Win")
        {
           standBy = true;
        }
    }
	
	void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SafeZone")
        {
            GameValues.numPax--;
			Destroy(gameObject);
        }
    }

    private void SetDifficulty(){
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
	
    public void Jump(){
        if (isGrounded && !isJumping){
            StartCoroutine(WaitForJump());
            isJumping = true;
            StartCoroutine(NotJumping());
        }  
    }

	IEnumerator WaitForJump()
    {
        yield return new WaitForSeconds(delay * 0.1f);
		rb2d.AddForce(Vector2.up * jumpForce * 100);
        rb2d.AddForce(Vector2.right * 200f);
	}

    IEnumerator StartRunning()
    {
        yield return new WaitForSeconds(2f);
		standBy = false;
	}

    IEnumerator NotJumping()
    {
        yield return new WaitForSeconds(0.25f);
		isJumping = false;
	}
}
