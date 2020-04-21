using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSubtitle : MonoBehaviour
{
    private Text subtitle;
    private int rand;
    string[] sentences;

    void Start()
    {
        subtitle = GetComponent<Text>();
        sentences = new string[] {
            "The roof is on fire!", 
            "Mmmmmmmadrid", 
            "Chami's Ranchero",
            "I'm a little strawberry. Eat me!",
            "Do de roar!",
            "Team Mocket takes off again...",
            "3, 2, 1... Centurion!",
            "Paella Toros, Olé Olé",
            "Once BESTie, always BESTie",
            "Mongolians!",
            "If your LBG is suspended clap your hands",
            "Beware of Carlinhos",
            "La lisiadaaaaaa",
            "Every where we gooo",
            "Afterparty",
            "Madre mmmmmia",
            "Viva La Patrona!",
            "Prueba superada..."

        };
        GenerateText();
    }

    public void GenerateText(){
        subtitle.text = sentences[Random.Range(0, sentences.Length)];
    }
}
