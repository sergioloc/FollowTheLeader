using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
	public string next;	
	
	public void GoWithAnimation(){
        GameValues.skipRules = false;
        GameValues.paxWaiting = true;
		GetComponent<Animator>().SetTrigger("Click");
		StartCoroutine(GoToScene());
	}

    public void GoWithoutAnimation(){
        SceneManager.LoadScene(next);
    }

    public void RestartWithAnimation(){
        GameValues.skipRules = true;
		GetComponent<Animator>().SetTrigger("Click");
		StartCoroutine(GoToScene());
	}
	
	IEnumerator GoToScene()
    {
        yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene(next);
	}
}
