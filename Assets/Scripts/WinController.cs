using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    public GameObject winFrame;

    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(ShowFrame());
        }
    }

    IEnumerator ShowFrame()
    {
        yield return new WaitForSeconds(1f);
		winFrame.SetActive(true);
        if ((GameValues.difficulty == 3 || GameValues.difficulty == 4) && PlayerPrefs.GetInt("SergioLock") == 0){
            PlayerPrefs.SetInt("SergioLock", 1);
            winFrame.GetComponent<Animator>().SetBool("UnlockSergio", true);
        }
	}


}
