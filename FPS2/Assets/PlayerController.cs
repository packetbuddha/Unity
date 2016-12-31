using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {



	private float xMov;
	private float zMov;
	private float xRot;
	private float yRot;

	private PlayerMotor motor;

    private Vector3 playerVelocity;
    private Vector3 playerRotation;
    private Vector3 positionHorizontal;
    private Vector3 positionVertical;
    private Vector3 cameraRotationX;

    private void Start ()
	{
		motor = GetComponent<PlayerMotor> ();

        // Lock the mouse pointer so it doesn't interfere with player movment
        Cursor.lockState = CursorLockMode.Locked;
	}

	private void Update ()
	{
        // Raw provides inputs which are always [-1, 0 or 1]
		xMov = Input.GetAxisRaw ("Horizontal");
		zMov = Input.GetAxisRaw ("Vertical");

        //Debug.Log("xMov: " + xMov + "; zMov: " + zMov);
        //Debug.Log("transform.right: " + transform.right);
        //Debug.Log("transofrm.forward: " + transform.forward);

        // transfor.right and transform.forward are the world space vectors, relative to the players rotation
        // So, as the player rotates, 'forward' and 'right' become relative values. We use these to construct
        // our final player velocity vector.
        // For example:
        // forward start = (0, 0, 1)
        // right start = (1, 0, 0)
        // as we rotate to the right (clockwise), about 45 degress, these values become relative...
        // our new forward = (.7, 0, .7)
        // our new right = = (.7, 0, -.7)
        positionHorizontal = transform.right * xMov;
        positionVertical = transform.forward * zMov;

        // Create a velocity vector. Normalized ensures the magnitude is always 1.
        // Magnitude is computed as sqrt(x*x + y*y + z*z). Magnitude is out speed reference.
        // Without normalized, movement at a diagonal (x=1, y=1) has a magnitude of 1.414.
        // So, in this case, it's keeping speed consistent.
        playerVelocity = (positionHorizontal + positionVertical).normalized;

        // Camera Rotation

        // Mouse movement will be a value between -1...1
		yRot = Input.GetAxisRaw ("Mouse X");
        xRot = Input.GetAxisRaw ("Mouse Y");

        Debug.Log("xRot: " + xRot + "yRot: " + yRot);
     
		playerRotation = new Vector3(0f, yRot, 0f);
		cameraRotationX = new Vector3 (-xRot, 0.0f, 0.0f);

		motor.Move (playerVelocity);
		motor.Rotate (playerRotation);
        motor.CameraRotate(cameraRotationX);

        // Relase the mouse pointer by hitting escape
        if (Input.GetKeyDown("escape")) {
            Cursor.lockState = CursorLockMode.None;
        }

	}
}
