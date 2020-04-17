using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderButton : MonoBehaviour
{
	public Animator animMorales, animJorge, animMaria, animDani, animAdri, animRichi, animVicthor, animSandia, animCarlos, animAlan;
	private bool isMoralesPressed, isJorgePressed, isMariaPressed, isDaniPressed, isAdriPressed, isRichiPressed, isVicthorPressed, isSandiaPressed, isCarlosPressed, isAlanPressed;
	private Animator animPrev;
	
    void Start()
    {
		isMoralesPressed = false;
		isJorgePressed = false;
		isMariaPressed = false;
		isDaniPressed = false;
		isAdriPressed = false;
		isRichiPressed = false;
		isVicthorPressed = false;
		isSandiaPressed = false;
		isCarlosPressed = false;
		isAlanPressed = false;
		animPrev = animAlan;
    }
	
	public void ClickMorales(){
		isMoralesPressed = Click(isMoralesPressed, animMorales, 1);
	}

	public void ClickJorge(){
		isJorgePressed = Click(isJorgePressed, animJorge, 2);
	}

	public void ClickMaria(){
		isMariaPressed = Click(isMariaPressed, animMaria, 3);
	}

	public void ClickDani(){
		isDaniPressed = Click(isDaniPressed, animDani, 4);
	}

	public void ClickAdri(){
		isAdriPressed = Click(isAdriPressed, animAdri, 5);
	}

	public void ClickRichi(){
		isRichiPressed = Click(isRichiPressed, animRichi, 6);
	}

	public void ClickVicthor(){
		isVicthorPressed = Click(isVicthorPressed, animVicthor, 7);
	}

	public void ClickSandia(){
		isSandiaPressed = Click(isSandiaPressed, animSandia, 8);
	}

	public void ClickCarlos(){
		isCarlosPressed = Click(isCarlosPressed, animCarlos, 9);
	}

	public void ClickAlan(){
		isAlanPressed = Click(isAlanPressed, animAlan, 10);
	}

	private bool Click(bool isPressed, Animator anim, int value){
		if (isPressed){
			anim.SetBool("isPressed", false);
			GameValues.leader = 0;
			return false;
		}
		else {
			GameValues.leader = value;
			animPrev.SetBool("isPressed", false);
			anim.SetBool("isPressed", true);
			animPrev = anim;
			return true;
		}
	}
}
