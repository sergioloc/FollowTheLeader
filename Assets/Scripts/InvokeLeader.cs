using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeLeader : MonoBehaviour
{
	public GameObject morales;
	
    void Start()
    {
        if (LeaderValue.value == 1){
			morales.SetActive(true);
		}
		else if (LeaderValue.value == 2){
			//morales.SetActive(true);
		}
    }
}
