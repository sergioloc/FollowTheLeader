using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoButton : MonoBehaviour
{
    public GameObject button;

    void FixedUpdate()
    {
        if (GameValues.leader != 0 && GameValues.difficulty != 0){
            button.SetActive(true);
        }
        else {
            button.SetActive(false);
        }
    }
}
