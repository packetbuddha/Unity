using UnityEngine;
using System.Collections;

public class BrickSpawn : MonoBehaviour {
	public int bricksPerRow = 14;
	public int rows = 3;

	private float xPosStart = 1.5f;
	private float xPos = 1.5f;
	private float yPos = 10.85f;

	private string fabPrefix = "hit";
	public int fabMax;

	void Start ()
	{
		// create a new row
		for (int row = 1; row <= rows; row++) {

			// add bricks to the row
			for (int col = 1; col <= bricksPerRow; col++) {

				// determine how many prefabs we have
				//fabMax = Resources.LoadAll("Prefabs").Length;

				// instansiate a random prefab
				string clone = "Prefabs/" + fabPrefix + Random.Range (1, fabMax + 1).ToString();
				Instantiate(Resources.Load(clone), new Vector3(xPos, yPos, 0), Quaternion.identity);
				xPos += 1;
			}
			yPos -= .33f;
			xPos = xPosStart;
		}

	}


}
