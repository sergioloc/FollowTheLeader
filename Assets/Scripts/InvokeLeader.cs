using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeLeader : MonoBehaviour
{
	public GameObject morales, jorge, lujan, dani, adri, richi, victhor, sandia, carlos, alan, sergio;
	
    void Start()
    {
        if (GameValues.leader == 1){
			morales.SetActive(true);
		}
		else if (GameValues.leader == 2){
			jorge.SetActive(true);
		}
		else if (GameValues.leader == 3){
			lujan.SetActive(true);
		}
		else if (GameValues.leader == 4){
			dani.SetActive(true);
		}
		else if (GameValues.leader == 5){
			adri.SetActive(true);
		}
		else if (GameValues.leader == 6){
			richi.SetActive(true);
		}
		else if (GameValues.leader == 7){
			victhor.SetActive(true);
		}
		else if (GameValues.leader == 8){
			sandia.SetActive(true);
		}
		else if (GameValues.leader == 9){
			carlos.SetActive(true);
		}
		else if (GameValues.leader == 10){
			alan.SetActive(true);
		}
		else if (GameValues.leader == 11){
			sergio.SetActive(true);
		}
    }
}
