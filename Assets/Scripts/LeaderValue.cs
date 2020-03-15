using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderValue : MonoBehaviour
{
	static public int value;
	
	public void ChooseMorales(){
		value = 1;
		SceneManager.LoadScene("SampleScene");
	}
	
	public void ChooseJorge(){
		value = 2;
		SceneManager.LoadScene("SampleScene");
	}
}