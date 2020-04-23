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

    public GameObject dieParticle;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;
    private Animator anim;
    private bool isAlive;
	
	private Rigidbody2D rb2d;
    private bool added = false;


    void Start()
    {
        isAlive = true;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		if (GameValues.speed != 0){
            speed = GameValues.speed;
            jumpForce = GameValues.jumpForce;
            rb2d.gravityScale = GameValues.gravity;
        }
        else{
            speed = 10;
            jumpForce = 16;
            rb2d.gravityScale = 5;
        }
    }

    void FixedUpdate()
    {
        if (initialGroup && !GameValues.paxWaiting)
            StartCoroutine(Run(2f));
            
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        anim.SetBool("isGrounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.Space))
        {
			Jump();
		}
        
		if (!standBy && !GameValues.paxWaiting){
			rb2d.transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.SetBool("isRunning", true);
		}	
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Shadow")
        {
            Die();
        }
    }
	
	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Win")
        {
           StartCoroutine(Win());
        }
        else if (collision.gameObject.tag == "DeadZone" || collision.gameObject.tag == "DeadPAX")
        {
           Die();
        }
        else if (collision.gameObject.tag == "Horde" && !initialGroup)
        {
			DelayRunning();
        }
    }
	
    public void Jump(){
        if (isGrounded && !standBy){
            StartCoroutine(WaitForJump());
        }  
    }

    private void DelayRunning(){
        int type = Random.Range(1, 3); //fast, normal, slow
            SetValues(type);
			if (!added){
				GameValues.numPax++;
				added = true;
			}
    }

    private void SetValues(int type)
	{
		float sec = 0;
		
		if (type == 1){ //fast
			delay = 1;
			sec = Random.Range(0, 0.1f);
		}
		else if (type == 2){ //normal
			delay = 2;
			sec = Random.Range(0.15f, 0.35f);
		}
		else { //slow
			delay = 3;
			sec = Random.Range(0.4f, 0.6f);
		}
		StartCoroutine(Run(sec));
	}

    IEnumerator Run(float sec)
    {
        yield return new WaitForSeconds(sec);
		standBy = false;
	}

    private void Die(){
        if (isAlive){
            isAlive = false;
            Instantiate(dieParticle, gameObject.transform.position, gameObject.transform.rotation);
            dieParticle.SetActive(true);
            GameValues.numPax--;
		    Destroy(gameObject);
        }
    }

    IEnumerator Win(){
        yield return new WaitForSeconds(1.2f);
        GameValues.paxWaiting = true;
        anim.SetBool("isRunning", false);
    }

	IEnumerator WaitForJump()
    {
        yield return new WaitForSeconds(delay * 0.1f);
		rb2d.AddForce(Vector2.up * jumpForce * 100);
        rb2d.AddForce(Vector2.right * 200f);
	}
}
