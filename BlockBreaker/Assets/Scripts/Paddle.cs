using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    float x;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        x = Input.mousePosition.x / Screen.width * 16;
        if (x <= 1 | x >= 15) {
            print("Hey, you're going out of bounds!");
        }
    }
}
