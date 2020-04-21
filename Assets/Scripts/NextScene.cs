using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
	public string next;	
	
	public void GoWithAnimation(){
		TransitionController.inAnim = true;
        GameValues.skipRules = false;
        GameValues.paxWaiting = true;
		GetComponent<Animator>().SetTrigger("Click");
		StartCoroutine(GoToScene());
	}

    public void GoWithoutAnimation(){
		TransitionController.inAnim = true;
        StartCoroutine(LoadNextScene());
    }

    public void RestartWithAnimation(){
		TransitionController.inAnim = false;
        GameValues.skipRules = true;
		GetComponent<Animator>().SetTrigger("Click");
		StartCoroutine(GoToScene());
	}
	
	IEnumerator GoToScene()
    {
        yield return new WaitForSeconds(0.5f);
		StartCoroutine(LoadNextScene());
	}

	IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(next);
	}
}
