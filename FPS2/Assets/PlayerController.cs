using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	float speedMultiplier = 5.0f;
	float lookSensitivity = 50.0f;

	float xMov;
	float zMov;
	float xRot;
	float yRot;

	PlayerMotor motor;

	Vector3 playerVelocity = Vector3.zero;
	Vector3 playerRotation = Vector3.zero;
	Vector3 moveHorizontal = Vector3.zero;
	Vector3 moveVertical = Vector3.zero;
	 
	//Vector3 cameraRotationX = Vector3.zero;

	private void Start ()
	{
		motor = GetComponent<PlayerMotor> ();
	}

	private void Update ()
	{
		xMov = Input.GetAxisRaw ("Horizontal");
		zMov = Input.GetAxisRaw ("Vertical");

		Debug.Log("xMov: " + xMov + "; zMov: " + zMov);
		Debug.Log("transform.right: " + transform.right);
		Debug.Log("transofrm.forward: " + transform.forward);

		// transform.right is the horizontal value, relative to the object (not world space)
		moveHorizontal = transform.right * xMov;
		moveVertical = transform.forward * zMov;

		playerVelocity = (moveHorizontal + moveVertical).normalized * speedMultiplier;

		yRot = Input.GetAxisRaw ("Mouse X") * lookSensitivity;
		//xRot += Input.GetAxisRaw ("Mouse Y") * lookSensitivity;

		// Calculate move vector
		playerRotation = new Vector3(0f, yRot, 0f);
		//cameraRotationX = new Vector3 (-xRot, 0.0f, 0.0f);


		motor.Move (playerVelocity);
		
		motor.Rotate (playerRotation);

		//if (cameraRotationX != Vector3.zero) {
		//	motor.CameraRotate (cameraRotationX);
		//}

	}
}
