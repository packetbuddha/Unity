using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TextController : MonoBehaviour {

	public Text text;

	private enum State
	{
		cell,
		lock_0,
		sheets_0,
		mirror,
		sheets_1,
		lock_1,
		cell_mirror
	}

	Dictionary<State, System.Action> stateMap = new Dictionary<State, System.Action>();

	private State myState;

	// Use this for initialization
	void Start () {
		
		stateMap.Add(State.cell, cell);
		stateMap.Add(State.sheets_0, sheets_0);
		stateMap.Add(State.mirror, mirror);
		stateMap.Add(State.lock_0, lock_0);
		stateMap.Add(State.lock_1, lock_1);
		stateMap.Add(State.sheets_1, sheets_1);
		stateMap.Add(State.cell_mirror, cell_mirror);

		myState = State.cell;

	}	

	// Update is called once per frame
	void Update ()
	{
		print (myState);
		/*
		if 		(myState == State.cell) 		{cell ();} 
		else if (myState == State.sheets_0) 	{sheets_0 ();}
		else if (myState == State.mirror) 		{mirror ();}
		else if (myState == State.lock_0) 		{lock_0 ();}
		else if (myState == State.lock_1) 		{lock_1 ();}
		else if (myState == State.sheets_1) 	{sheets_1 ();}
		else if (myState == State.cell_mirror) 	{cell_mirror ();}
		*/
		stateMap[myState]();



	}
	void cell ()
	{
		text.text = "You wake with a dry tounge in a stone walled room. With slured eyes you gaze to the left and see a door made of rusty iron " +
		". The room is damp and cool. To the right you see an aged, broken mirror desperately clinging to the wall " +
		"Beneath your hollowed body are torn, rancid sheets. You will yourself from the bed to find the door locked from the outside.\n\n" +
		"Press S to inspect the Sheets, M to look into the Mirror, L to inspect the Lock."; 
		if 		(Input.GetKeyDown (KeyCode.S)) 	{myState = State.sheets_0;} 
		else if (Input.GetKeyDown (KeyCode.M)) 	{myState = State.mirror;}
		else if (Input.GetKeyDown (KeyCode.L)) 	{myState = State.lock_0;}
	}
	void sheets_0 ()
	{
		text.text = "If these sheets could talk...you would tell them to shut up.\n\n" +
					"Press R to Return to roaming your cell.";
		if (Input.GetKeyDown (KeyCode.R))		{myState = State.cell;}
	}

	void sheets_1 ()
	{
		text.text = "If these sheets could talk...you would tell them to shut up.\n\n" +
					"Press R to Return to using the mirror.";
		if (Input.GetKeyDown (KeyCode.R))		{myState = State.cell_mirror;}
	}

	void mirror ()
	{
		text.text = "Looking in the mirror was a mistake... you look like shit.\n\n" +
					"Press R to Return to roaming your cell or T to Take the mirror";
		if 		(Input.GetKeyDown (KeyCode.R)) 	{myState = State.cell;}
		else if (Input.GetKeyDown (KeyCode.T)) 	{myState = State.cell_mirror;}
	}

	void cell_mirror ()
	{
		text.text = "You take a part of the broken mirror in your hands.\n\n" +
					"Press R to Return to roaming your cell or S to use the mirror on the " +
					"Sheets, or L to use the mirror on the Lock";
		if 		(Input.GetKeyDown (KeyCode.R)) 	{myState = State.cell;}
		else if (Input.GetKeyDown (KeyCode.T)) 	{myState = State.cell_mirror;}
		else if (Input.GetKeyDown (KeyCode.S)) 	{myState = State.sheets_1;}
		else if (Input.GetKeyDown (KeyCode.L)) 	{myState = State.lock_1;}
	}


	void lock_0 ()
	{
		text.text = "The lock is on the outside of the door so you can't get a good look at it.\n\n" +
					"Press R to Return to roaming your cell.";
		if (Input.GetKeyDown (KeyCode.R))		{myState = State.cell;}
	}

	void lock_1 ()
	{
		text.text = "Using the mirror, you are able to see and use the lock! Freedom!.\n\n" +
					"Press R to Return to roaming your cell.";
		if (Input.GetKeyDown (KeyCode.R))		{myState = State.cell;}
	}

}
