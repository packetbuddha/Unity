using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	Vector3 paddlePos;
	bool click = false;

	void Update ()
	{
		if (!click) {
			paddlePos = GameObject.Find ("Paddle").transform.position;
			this.transform.position = new Vector3 (paddlePos.x, (paddlePos.y + .35f), 0f);

			if (Input.GetMouseButtonDown (0)) {
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (5f, 10f);
				click = true;
			}
		}
	}
}
