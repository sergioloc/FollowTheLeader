using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeLeader : MonoBehaviour
{
	public GameObject morales, jorge, dani;
	
    void Start()
    {
        if (GameValues.leader == 1){
			morales.SetActive(true);
		}
		else if (GameValues.leader == 2){
			jorge.SetActive(true);
		}
		else if (GameValues.leader == 4){
			dani.SetActive(true);
		}
    }
}
