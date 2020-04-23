using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaxNumber : MonoBehaviour
{
    public GameObject characters, pax, gameOver;
    private Text paxText;
    public Text description;
    
    void Start(){
        GameValues.numPax = GameValues.initialNumPax;
        paxText = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        if (GameValues.numPax < 1){
            paxText.text = "PAX: 0";
            if (characters.activeSelf)
                Die();
        }
        else {
            paxText.text = "PAX: " + GameValues.numPax.ToString();
        }
    }
    
    private void Die(){
        StartCoroutine(GameOver());
        characters.SetActive(false);
        pax.SetActive(false);
    }

    IEnumerator GameOver(){
        yield return new WaitForSeconds(1f);
        description.text = "ALL YOUR PAX DIED!";
        gameOver.SetActive(true);
    }
}
