using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameValues : MonoBehaviour
{
    static public int leader;
	static public int difficulty;
	
	public void ChooseMorales(){
		leader = 1;
	}
	
	public void ChooseJorge(){
		leader = 2;
	}
	
	public void Observer(){
		difficulty = 1;
	}
	
	public void Baby(){
		difficulty = 2;
	}
	
	public void Full(){
		difficulty = 3;
	}
	
	public void Alumnus(){
		difficulty = 4;
	}
}
