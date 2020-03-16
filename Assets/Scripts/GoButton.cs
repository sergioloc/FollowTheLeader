using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoButton : MonoBehaviour
{
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameValues.leader != 0 && GameValues.difficulty != 0){
            button.SetActive(true);
        }
        else {
            button.SetActive(false);
        }
    }
}
