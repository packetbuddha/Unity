using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	Text myGuess;

	int guess;

	public int max;
	public int min;
	public int maxGuesses;
 
 	void Start ()
	{
		myGuess = GetComponent<Text>();
		NextGuess();
	}

	public void GuessHigher ()
	{
		min = guess;
		NextGuess ();
	}

	public void GuessLower ()
	{
		max = guess;
		NextGuess();
	}

	void NextGuess ()
	{
		//guess = (max+min)/2;
		guess = Random.Range(min, max + 1);
		myGuess.text = "I guess, " + guess.ToString();
		maxGuesses -= 1;
		if (maxGuesses == -1) 
		{
			Application.LoadLevel("Win");
			Application.SceneMan
		}
	}

}
