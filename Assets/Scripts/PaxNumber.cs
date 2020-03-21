using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaxNumber : MonoBehaviour
{
    public GameObject leader, pax, gameOver;
    private Text paxText;
    void Start(){
        paxText = GetComponent<Text>();
    }
    void Update()
    {
        if (GameValues.numPax < 1){
            
        }
        else {
            paxText.text = "PAX: " + GameValues.numPax.ToString();
        }
    }

    private void GameOver(){
        Destroy(leader);
        Destroy(pax);
        gameOver.SetActive(true);
    }
}
