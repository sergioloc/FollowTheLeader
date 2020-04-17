using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
	public int speed = 0;
	private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
		Destroy(gameObject, 5f);
    }

    void FixedUpdate()
    {
		rb2d.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
	
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Shadow")
        {
            Destroy(col.gameObject);
			Destroy(gameObject);
        }
    }
}
