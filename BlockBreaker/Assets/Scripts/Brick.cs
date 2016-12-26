using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public int maxHits;
	private int currentHits;
	private AudioClip explosion;

	// Use this for initialization
	void Start () {
		currentHits = 0;
		GetComponent<AudioSource> ().playOnAwake = false;
		GetComponent<AudioSource> ().clip = explosion;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		currentHits++;
		print ("Hits: " + currentHits);
		if (currentHits == maxHits) {
			GetComponent<AudioSource> ().Play ();
			Destroy(gameObject);
		}
	}
}
