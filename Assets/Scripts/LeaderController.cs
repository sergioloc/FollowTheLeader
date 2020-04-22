using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.RemoteConfig;

public class LeaderController : MonoBehaviour
{
    
	private int jumpForce;
	private int speed;	
	public GameObject projectile, projectileYellow, die, characters;
	public Transform shotPoint;
	private Rigidbody2D rb2d;
    private float push = 200f;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;

    public GameObject ammo1, ammo2, ammo3, ammo4, gameOver, paxes;
    public Text description;
    public int currentAmmo = 0;
    private Animator animator;
    public GameObject morales, jorge, lujan, dani, adri, richi, victhor, sandia, carlos, alan, sergio, waterParticle;
    private bool isAlive;
	
    void Start()
    {
        isAlive = true;
        rb2d = GetComponent<Rigidbody2D>();
        speed = GameValues.speed;
        jumpForce = GameValues.jumpForce;
        rb2d.gravityScale = GameValues.gravity;
        SetLeader();
        SetAmmo();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        animator.SetBool("isGrounded", isGrounded);
        
        if (isAlive)
            rb2d.transform.Translate(Vector2.right * speed * Time.deltaTime);
		
		if (Input.GetKeyDown(KeyCode.Space))
        {
			Jump();
		}
		
		if (Input.GetKeyDown(KeyCode.A))
        {
			Attack();
		}
		
    }

    private void SetAmmo(){
        if (currentAmmo == 0){
            ammo1.SetActive(false);
            ammo2.SetActive(false);
            ammo3.SetActive(false);
            ammo4.SetActive(false);
        }
        else if (currentAmmo == 1){
            ammo1.SetActive(true);
            ammo2.SetActive(false);
            ammo3.SetActive(false);
            ammo4.SetActive(false);
        }
        else if (currentAmmo == 2){
            ammo1.SetActive(true);
            ammo2.SetActive(true);
            ammo3.SetActive(false);
            ammo4.SetActive(false);
        }
        else if (currentAmmo == 3){
            ammo1.SetActive(true);
            ammo2.SetActive(true);
            ammo3.SetActive(true);
            ammo4.SetActive(false);
        }
        else {
            ammo1.SetActive(true);
            ammo2.SetActive(true);
            ammo3.SetActive(true);
            ammo4.SetActive(true);
        }
    }

    public void Jump(){
        if(isGrounded && isAlive){
            rb2d.AddForce(Vector2.up * jumpForce * 100);
            rb2d.AddForce(Vector2.right * push);
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
        
        if (collision.gameObject.tag == "Water")
        {
            if (AddAmmo())
            {
                Instantiate(waterParticle, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
                Destroy(collision.gameObject);
                currentAmmo++;
            }
        }
        else if (collision.gameObject.tag == "DeadZone")
        {
           Die();
        }
        else if (collision.gameObject.tag == "Win")
        {
            animator.SetBool("Idle", true);
            speed = 0;
        }
    }
	
	void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SafeZone")
        {
			Die();
        }
    }

    private bool AddAmmo(){
        bool result = false;
        if (currentAmmo == 0)
        {
            ammo1.SetActive(true);
            result = true;
        }
        else if (currentAmmo == 1) 
        {
            ammo2.SetActive(true);
            result = true;
        }
        else if (currentAmmo == 2) 
        {
            ammo3.SetActive(true);
            result = true;
        }
        else if (currentAmmo == 3) 
        {
            ammo4.SetActive(true);
            result = true;
        }
        return result;
    }

    public void Attack(){
        if (currentAmmo > 0 && isAlive){
            animator.SetTrigger("Attack");
            if (GameValues.leader == 11)
                Instantiate(projectileYellow, shotPoint.position, shotPoint.rotation);
            else
                Instantiate(projectile, shotPoint.position, shotPoint.rotation);
            if (currentAmmo == 1)
            {
                ammo1.SetActive(false);
            }
            else if (currentAmmo == 2)
            {
                ammo2.SetActive(false);
            } 
            else if (currentAmmo == 3)
            {
                ammo3.SetActive(false);
            }
            else if (currentAmmo == 4)
            {
                ammo4.SetActive(false);
            }
            currentAmmo--;
        }
    }

    private void Die(){
        isAlive = false;
        die.SetActive(true);
        characters.SetActive(false);
        paxes.SetActive(false);
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver(){
        yield return new WaitForSeconds(2f);
        gameOver.SetActive(true);
        description.text = "Your leader died!";
    }

    private void SetLeader(){
        if (GameValues.leader == 1){
			morales.SetActive(true);
			animator = morales.GetComponent<Animator>();
		}
		else if (GameValues.leader == 2){
			jorge.SetActive(true);
			animator = jorge.GetComponent<Animator>();
		}
		else if (GameValues.leader == 3){
			lujan.SetActive(true);
			animator = lujan.GetComponent<Animator>();
		}
		else if (GameValues.leader == 4){
			dani.SetActive(true);
			animator = dani.GetComponent<Animator>();
		}
		else if (GameValues.leader == 5){
			adri.SetActive(true);
			animator = adri.GetComponent<Animator>();
		}
		else if (GameValues.leader == 6){
			richi.SetActive(true);
			animator = richi.GetComponent<Animator>();
		}
		else if (GameValues.leader == 7){
			victhor.SetActive(true);
			animator = victhor.GetComponent<Animator>();
		}
		else if (GameValues.leader == 8){
			sandia.SetActive(true);
			animator = sandia.GetComponent<Animator>();
		}
		else if (GameValues.leader == 9){
			carlos.SetActive(true);
		    animator = carlos.GetComponent<Animator>();
		}
		else if (GameValues.leader == 10){
			alan.SetActive(true);
			animator = alan.GetComponent<Animator>();
		}
		else if (GameValues.leader == 11){
			sergio.SetActive(true);
			animator = sergio.GetComponent<Animator>();
		}
        else{
            morales.SetActive(true);
			animator = morales.GetComponent<Animator>();
        }
    }
}
