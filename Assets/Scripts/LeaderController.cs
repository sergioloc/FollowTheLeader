using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderController : MonoBehaviour
{
    
	public int jumpForce = 0;
	public int speed = 10;	
	public GameObject projectile, fireworks;
	public Transform shotPoint;
	private Rigidbody2D rb2d;
    private float push = 200f;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool isGrounded;

    public GameObject ammo1, ammo2, ammo3, ammo4, gameOver;
    public Text description;
    public int currentAmmo = 0;
	
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        SetDifficulty();
        SetAmmo();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        
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
        if(isGrounded){
            rb2d.AddForce(Vector2.up * jumpForce * 100);
            rb2d.AddForce(Vector2.right * push);
        }
    }

	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ShadowAttack")
        {
            GameOver();
        }
        else if (collision.gameObject.tag == "Potion")
        {
            if (AddAmmo())
            {
                Destroy(collision.gameObject);
                currentAmmo++;
            }
        }
        else if (collision.gameObject.tag == "DeadZone")
        {
           GameOver();
        }
        else if (collision.gameObject.tag == "Win")
        {
            fireworks.SetActive(true);
           speed = 0;
        }
    }
	
	void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SafeZone")
        {
			GameOver();
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
        if (currentAmmo > 0){
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

    private void GameOver(){
        description.text = "Your leader died!";
        gameOver.SetActive(true);
        Destroy(gameObject);
    }
}
