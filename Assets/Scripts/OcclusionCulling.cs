using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcclusionCulling : MonoBehaviour
{
    public GameObject platforms, details, content;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SafeZone")
        {
            EnableAll();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SafeZone")
        {
            DisableAll();
        }
    }

    private void EnableAll(){
        platforms.SetActive(true);
        details.SetActive(true);
        content.SetActive(true);
    }

    private void DisableAll(){
        platforms.SetActive(false);
        details.SetActive(false);
        content.SetActive(false);
    }
}
