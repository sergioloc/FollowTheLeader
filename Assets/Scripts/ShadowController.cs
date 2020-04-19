
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    private Animator anim;
    private float distance;
    public GameObject player, dieParticle;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate(){
        distance = player.transform.position.x - transform.position.x;
        if (Mathf.Abs(distance) < 10){
            anim.SetBool("isAttacking", true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("WaterBall"))
        {
            dieParticle.SetActive(true);
            Destroy(gameObject);
        }
	}
}
