using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesController : MonoBehaviour
{
    public GameObject page1, page2, back, ui, music;
    private string actualPage = "Page1";

    void Start(){
        if (GameValues.skipRules){
            StartLevel();
        }
    }

    public void NextPage(){
        if (actualPage == "Page1"){
            page1.SetActive(false);
            page2.SetActive(true);
            back.SetActive(true);
            actualPage = "Page2";
        }
        else if (actualPage == "Page2"){
            StartLevel();
        }
    }

    public void PreviusPage(){
        if (actualPage == "Page2"){
            page1.SetActive(true);
            page2.SetActive(false);
            back.SetActive(false);
            actualPage = "Page1";
        }
    }

    private void StartLevel(){
        GameValues.paxWaiting = false;
        ui.SetActive(true);
        gameObject.SetActive(false);
        if(PlayerPrefs.GetInt("Mute") == 0)
            music.SetActive(true);
    }

}
