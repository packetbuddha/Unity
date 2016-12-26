using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	void Start ()
	{
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	void OnCollisionEnter2D (Collision2D collision) {
		print("Collision detected!");
	}
	void OnTriggerEnter2D (Collider2D trigger) {
		print("Trigger triggered!!");
		levelManager.LoadLevel ("Start");	

	}

}
