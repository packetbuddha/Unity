using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
	public float mousePosInBlocks;

    void Start()
    {
		Cursor.visible = false;
    }

    void Update()
    {
		// update the positional coordinates of the paddle
		// x = our current position, restricted to the boundaries of the game; y = current value; z = none
		this.transform.position = new Vector3(Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f), this.transform.position.y, 0.0f);

		// read mouse position on the x axis and convert into world-blocks
		mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

     }
}
