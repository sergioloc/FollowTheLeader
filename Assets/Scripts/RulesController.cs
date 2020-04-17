using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesController : MonoBehaviour
{
    public GameObject page1, page2, back, ui;
    private string actualPage = "Page1";

    public void NextPage(){
        Debug.Log(actualPage);
        if (actualPage == "Page1"){
            page1.SetActive(false);
            page2.SetActive(true);
            back.SetActive(true);
            actualPage = "Page2";
        }
        else if (actualPage == "Page2"){
            GameValues.paxWaiting = false;
            ui.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void PreviusPage(){
        Debug.Log(actualPage);
        if (actualPage == "Page2"){
            page1.SetActive(true);
            page2.SetActive(false);
            back.SetActive(false);
            actualPage = "Page1";
        }
    }

}
