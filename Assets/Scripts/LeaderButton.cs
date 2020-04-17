using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderButton : MonoBehaviour
{
	public Animator animMorales, animJorge;
	private bool isMoralesPressed, isJorgePressed;
	private string selected;
	
    void Start()
    {
		isMoralesPressed = false;
		isJorgePressed = false;
    }

	private void UpdateStatus(){
		if (selected == "Morales"){
			animMorales.SetBool("isPressed", true);
			animJorge.SetBool("isPressed", false);
		}
		else if (selected == "Jorge"){
			animMorales.SetBool("isPressed", false);
			animJorge.SetBool("isPressed", true);
		}
	}
	
	public void ClickMorales(){
		if (isMoralesPressed){
			animMorales.SetBool("isPressed", false);
			isMoralesPressed = false;
			GameValues.leader = 0;
		}
		else {
			selected = "Morales";
			UpdateStatus();
			isMoralesPressed = true;
			isJorgePressed = false;
			GameValues.leader = 1;
		}
	}

	public void ClickJorge(){
		if (isJorgePressed){
			animJorge.SetBool("isPressed", false);
			isJorgePressed = false;
			GameValues.leader = 0;
		}
		else {
			selected = "Jorge";
			UpdateStatus();
			isJorgePressed = true;
			isMoralesPressed = false;
			GameValues.leader = 2;
		}
	}
}
