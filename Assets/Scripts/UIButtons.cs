using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public void GoBackToChooseLeader(){
        GameValues.leader = 0;
        GameValues.difficulty = 0;
    }

    // Choose Leader
    private void MuteMusic(){

    }

}
