using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public GameObject mute, unmute, music;
    void Start()
    {
        SetIcons();
    }

    private void SetIcons(){
        if (PlayerPrefs.GetInt("Mute") == 1){
            mute.SetActive(true);
            unmute.SetActive(false);
            music.SetActive(false);
        }
        else {
            mute.SetActive(false);
            unmute.SetActive(true);
            music.SetActive(true);
        }
    }

    public void PressButton(){
        if (PlayerPrefs.GetInt("Mute") == 1){
            PlayerPrefs.SetInt("Mute", 0);
        }
        else {
            PlayerPrefs.SetInt("Mute", 1);
        }
        SetIcons();
    }


}
