using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAXJump : MonoBehaviour
{
    public GameObject[] pax;

    public void Jump(){
        for(int i = 0; i < pax.Length; i++){
            if (pax[i] != null){
                pax[i].GetComponent<PaxController>().Jump();
            }
        }
        
    }
}
