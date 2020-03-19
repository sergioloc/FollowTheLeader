using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
	public string next;
	private Animator anim;
	
    void Start()
    {
        anim = GetComponent<Animator>();
    }
	
	public void GoWithAnimation(){
		anim.SetTrigger("Click");
		StartCoroutine(GoToScene());
	}

    public void GoWithoutAnimation(){
        SceneManager.LoadScene(next);
    }
	
	IEnumerator GoToScene()
    {
        yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene(next);
	}
}
