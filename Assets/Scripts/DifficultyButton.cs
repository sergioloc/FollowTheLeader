using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyButton : MonoBehaviour
{
    public Animator animObserver, animBaby, animFull, animAlumnus;
    private bool isObserverPressed, isBabyPressed, isFullPressed, isAlumnusPressed;
    private string selected;

    void Start()
    {
        isObserverPressed = false;
        isBabyPressed = false;
        isFullPressed = false;
        isAlumnusPressed = false;
    }

    private void UpdateStatus(){
		if (selected == "Observer"){
			animObserver.SetBool("isPressed", true);
			animBaby.SetBool("isPressed", false);
            animFull.SetBool("isPressed", false);
            animAlumnus.SetBool("isPressed", false);
		}
		else if (selected == "Baby"){
			animObserver.SetBool("isPressed", false);
			animBaby.SetBool("isPressed", true);
            animFull.SetBool("isPressed", false);
            animAlumnus.SetBool("isPressed", false);
		}
        else if (selected == "Full"){
			animObserver.SetBool("isPressed", false);
			animBaby.SetBool("isPressed", false);
            animFull.SetBool("isPressed", true);
            animAlumnus.SetBool("isPressed", false);
		}
        else {
			animObserver.SetBool("isPressed", false);
			animBaby.SetBool("isPressed", false);
            animFull.SetBool("isPressed", false);
            animAlumnus.SetBool("isPressed", true);
		}
	}

    public void ClickObserver(){
        Debug.Log("Observer");
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
			isAlumnusPressed = false;
			GameValues.difficulty = 1;
		}
	}

    public void ClickBaby(){
        Debug.Log("Baby");
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
			isAlumnusPressed = false;
			GameValues.difficulty = 2;
		}
	}

    public void ClickFull(){
        Debug.Log("Full");
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
			isAlumnusPressed = false;
			GameValues.difficulty = 3;
		}
	}

    public void ClickAlumnus(){
        Debug.Log("Alumnus");
		if (isAlumnusPressed){
			animAlumnus.SetBool("isPressed", false);
			isAlumnusPressed = false;
			GameValues.difficulty = 0;
		}
		else {
			selected = "Alumnus";
			UpdateStatus();
			isObserverPressed = false;
			isBabyPressed = false;
			isFullPressed = false;
			isAlumnusPressed = true;
			GameValues.difficulty = 4;
		}
	}
}
