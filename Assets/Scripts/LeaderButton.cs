using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderButton : MonoBehaviour
{
	public Animator animMorales, animJorge, animMaria, animDani, animAdri, animRichi, animVicthor, animSandia, animCarlos, animAlan, animSergio, animLucia;
	private bool isMoralesPressed, isJorgePressed, isMariaPressed, isDaniPressed, isAdriPressed, isRichiPressed, isVicthorPressed, isSandiaPressed, isCarlosPressed, isAlanPressed, isSergioPressed, isLuciaPressed;
	private Animator animPrev;

	public Text textSergio, textLucia;
	
    void Start()
    {
		PlayerPrefs.SetInt("SergioLock", 0);
		PlayerPrefs.SetInt("LuciaLock", 0);
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
		isSergioPressed = false;
		if (PlayerPrefs.GetInt("SergioLock") == 0)
			animSergio.SetBool("isLock", true);
		else{
			animSergio.SetBool("isLock", false);
			textSergio.text = "Sergio";
		}
		if (PlayerPrefs.GetInt("LuciaLock") == 0)
			animLucia.SetBool("isLock", true);
		else{
			animLucia.SetBool("isLock", false);
			textLucia.text = "Lucia";
		}	
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

	public void ClickSergio(){
		if (PlayerPrefs.GetInt("SergioLock") == 1)
			isSergioPressed = Click(isSergioPressed, animSergio, 11);
	}

	private bool Click(bool isPressed, Animator anim, int value){
		if (isPressed){
			anim.SetBool("isPressed", false);
			GameValues.leader = 0;
			return false;
		}
		else {
			GameValues.leader = value;
			anim.SetBool("isPressed", true);
			if (animPrev != null)
				animPrev.SetBool("isPressed", false);
			animPrev = anim;
			return true;
		}
	}
}
