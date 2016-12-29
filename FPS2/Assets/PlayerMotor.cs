using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	[SerializeField]
	private Camera cam;
	private Rigidbody rb;

	private Vector3 playerVelocity;
	private Vector3 playerRotation;


	private void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	public void  Move (Vector3 _playerVelocity)
	{
		playerVelocity = _playerVelocity * Time.fixedDeltaTime;
	}

	public void Rotate (Vector3 _playerRotation)
	{
		playerRotation = _playerRotation * Time.fixedDeltaTime;
	}

	public void CameraRotate (Vector3 _cameraRotationX)
	{
		cam.transform.eulerAngles = _cameraRotationX;
	}

	private void PeformPlayerMove ()
	{
		rb.MovePosition (rb.position + playerVelocity);
	}

	private void PerformPlayerRotate ()
	{
		rb.MoveRotation (rb.rotation * Quaternion.Euler(playerRotation));
	}

	private void PerformCameraRotate ()
	{
		
	}

	private void FixedUpdate ()
	{
		PeformPlayerMove();
		PerformPlayerRotate();
	}
	
}
