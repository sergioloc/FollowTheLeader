using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    public GameObject blueHole, yellowHole, leader;
    private GameObject hole;
    void Start()
    {
        if (GameValues.leader == 11)
            hole = yellowHole;
        else
            hole = blueHole;
        StartCoroutine(StartBlueHole());
    }

    IEnumerator StartBlueHole(){
        yield return new WaitForSeconds(1f);
        hole.SetActive(true);
        StartCoroutine(StartLevel());
    }

    IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(1f);
		Destroy(hole);
        leader.SetActive(true);
	}
}
