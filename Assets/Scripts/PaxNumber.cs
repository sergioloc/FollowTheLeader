using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaxNumber : MonoBehaviour
{
    public GameObject leader, pax, gameOver;
    private Text paxText;
    public Text description;
    
    void Start(){
        GameValues.numPax = GameValues.initialNumPax;
        paxText = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        if (GameValues.numPax < 1 && !leader.activeSelf){
            paxText.text = "PAX: 0";
            Die();
        }
        else {
            paxText.text = "PAX: " + GameValues.numPax.ToString();
        }
    }
    
    private void Die(){
        StartCoroutine(GameOver());
        leader.SetActive(false);
        pax.SetActive(false);
    }

    IEnumerator GameOver(){
        yield return new WaitForSeconds(2f);
        description.text = "All your PAXes died!";
        gameOver.SetActive(true);
    }
}
