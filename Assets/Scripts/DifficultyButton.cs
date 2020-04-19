using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButton : MonoBehaviour
{
    public Animator animObserver, animBaby, animFull, animAlumni;
    private bool isObserverPressed, isBabyPressed, isFullPressed, isAlumniPressed;
    private string selected;

    void Start()
    {
        isObserverPressed = false;
        isBabyPressed = false;
        isFullPressed = false;
        isAlumniPressed = false;
    }

    private void UpdateStatus(){
		if (selected == "Observer"){
			animObserver.SetBool("isPressed", true);
			animBaby.SetBool("isPressed", false);
            animFull.SetBool("isPressed", false);
            animAlumni.SetBool("isPressed", false);
		}
		else if (selected == "Baby"){
			animObserver.SetBool("isPressed", false);
			animBaby.SetBool("isPressed", true);
            animFull.SetBool("isPressed", false);
            animAlumni.SetBool("isPressed", false);
		}
        else if (selected == "Full"){
			animObserver.SetBool("isPressed", false);
			animBaby.SetBool("isPressed", false);
            animFull.SetBool("isPressed", true);
            animAlumni.SetBool("isPressed", false);
		}
        else {
			animObserver.SetBool("isPressed", false);
			animBaby.SetBool("isPressed", false);
            animFull.SetBool("isPressed", false);
            animAlumni.SetBool("isPressed", true);
		}
	}

    public void ClickObserver(){
		if (isObserverPressed){
			animObserver.SetBool("isPressed", false);
			isObserverPressed = false;
			GameValues.difficulty = 0;
		}
		else {
			selected = "Observer";
			UpdateStatus();
			isObserverPressed = true;
			isBabyPressed = false;
			isFullPressed = false;
			isAlumniPressed = false;
			GameValues.difficulty = 1;
		}
	}

    public void ClickBaby(){
		if (isBabyPressed){
			animBaby.SetBool("isPressed", false);
			isBabyPressed = false;
			GameValues.difficulty = 0;
		}
		else {
			selected = "Baby";
			UpdateStatus();
			isObserverPressed = false;
			isBabyPressed = true;
			isFullPressed = false;
			isAlumniPressed = false;
			GameValues.difficulty = 2;
		}
	}

    public void ClickFull(){
		if (isFullPressed){
			animFull.SetBool("isPressed", false);
			isFullPressed = false;
			GameValues.difficulty = 0;
		}
		else {
			selected = "Full";
			UpdateStatus();
			isObserverPressed = false;
			isBabyPressed = false;
			isFullPressed = true;
			isAlumniPressed = false;
			GameValues.difficulty = 3;
		}
	}

    public void ClickAlumni(){
		if (isAlumniPressed){
			animAlumni.SetBool("isPressed", false);
			isAlumniPressed = false;
			GameValues.difficulty = 0;
		}
		else {
			selected = "Alumni";
			UpdateStatus();
			isObserverPressed = false;
			isBabyPressed = false;
			isFullPressed = false;
			isAlumniPressed = true;
			GameValues.difficulty = 4;
		}
	}
}
