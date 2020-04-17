using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSubtitle : MonoBehaviour
{
    private Text subtitle;
    private int rand;

    void Start()
    {
        subtitle = GetComponent<Text>();
        GenerateText();
    }

    public void GenerateText(){
        rand = Random.Range(1, 3);
        if (rand == 1){
            subtitle.text = "the roof is on fire!";
        }
        else {
            subtitle.text = "Mmmmmmadrid";
        }
    }
}
