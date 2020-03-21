using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    public GameObject blueHole, leader;
    void Start()
    {
        StartCoroutine(StartBlueHole());
    }

    IEnumerator StartBlueHole(){
        yield return new WaitForSeconds(1f);
        blueHole.SetActive(true);
        StartCoroutine(StartLevel());
    }

    IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(1f);
		Destroy(blueHole);
        leader.SetActive(true);
	}
}
