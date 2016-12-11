using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	

	public void LoadLevel (string name)
	{
	Application.LoadLevel(name); 
	//SceneManager.LoadScene(name);
	}

	public void QuitRequest ()
	{
	Debug.Log("Quitter!: ");
	Application.Quit();
	}
}
