using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameValues : MonoBehaviour
{
    static public int leader;
	static public int difficulty;
	static public int numPax;
	static public int initialNumPax = 9;
	static public bool paxWaiting = true;
	static public bool skipRules = false;
	static public Animator animator;
	static public bool isLeaderAlive;

	static public int speed;
	static public int speedObserver;
	static public int speedBaby;
	static public int speedFull;
	static public int speedAlumni;
	static public int jumpForce;
	static public int gravity;
}
