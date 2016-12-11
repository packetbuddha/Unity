using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {
	// Use this for initialization

	int max;
	int min;
	int guess;

	void Start ()
	{
		max = 1000;
		min = 1;
		guess = 500;

		print ("Welcome to Number Wizard");
		print ("Pick a number in your head, but don't tell me!");

		print ("The highest number you can pick " + max.ToString ());
		print ("The lowest number you can pick " + min.ToString ());
		NextGuess();
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			min = guess;
			NextGuess();

		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			max = guess;
			NextGuess();

		} else if (Input.GetKeyDown (KeyCode.Return)) {
			print ("I win!");
			print ("======================");

			Start();
		}

	}

	void NextGuess() {
		guess = (max+min)/2;
		print ("Is the number higher or lower than " + guess.ToString() + "?");
		print ("Up arrow for higher, down arrow for lower, Enter for equals");

	}

}
