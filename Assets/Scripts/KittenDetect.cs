using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KittenDetect : MonoBehaviour
{
    public GameObject shadow;
	
	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shadow.SetActive(true);
            Destroy(gameObject);
        }
	}
}
