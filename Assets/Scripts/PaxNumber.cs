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
        paxText = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        if (GameValues.numPax < 1){
            paxText.text = "PAX: 0";
            GameOver();
        }
        else {
            paxText.text = "PAX: " + GameValues.numPax.ToString();
        }
    }

    private void GameOver(){
        description.text = "All your PAXes died!";
        Destroy(leader);
        Destroy(pax);
        gameOver.SetActive(true);
    }
}
