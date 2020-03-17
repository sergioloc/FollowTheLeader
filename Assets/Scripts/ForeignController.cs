using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeignController : MonoBehaviour
{
	private PaxController paxController;
	
	void Start(){
		paxController = GetComponent<PaxController>();
		paxController.standBy = true;
	}
	
	void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Horde")
        {
			int type = Random.Range(1, 3); //fast, normal, slow
			Debug.Log(type);
            setValues(type);
        }
	}
	
	private void setValues(int type)
	{
		float sec = 0;
		
		if (type == 1){ //fast
			paxController.delay = 1;
			sec = Random.Range(0, 0.1f);
		}
		else if (type == 2){ //normal
			paxController.delay = 2;
			sec = Random.Range(0.15f, 0.35f);
		}
		else { //slow
			paxController.delay = 3;
			sec = Random.Range(0.4f, 0.6f);
		}
		StartCoroutine(Run(sec));
	}
	
	IEnumerator Run(float sec)
    {
        yield return new WaitForSeconds(sec);
		paxController.standBy = false;
	}
}
