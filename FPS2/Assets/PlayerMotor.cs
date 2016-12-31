using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	[SerializeField] private Camera cam;
    [SerializeField] float speedMultiplier = 25.0f;
    [SerializeField] float lookSensitivity = 60.0f;

    private Rigidbody rb;
	private Vector3 playerVelocity = Vector3.zero;
	private Vector3 playerRotation = Vector3.zero;
    private Vector3 cameraRotationX = Vector3.zero;


    private void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	public void  Move (Vector3 _playerVelocity)
	{
		playerVelocity = _playerVelocity * speedMultiplier * Time.fixedDeltaTime;
	}

	public void Rotate (Vector3 _playerRotation)
	{
		playerRotation = _playerRotation * lookSensitivity * Time.fixedDeltaTime;
	}

	public void CameraRotate (Vector3 _cameraRotationX)
	{
		cameraRotationX = _cameraRotationX * lookSensitivity * Time.fixedDeltaTime;
    }

	private void PeformPlayerMove ()
	{
        //Debug.Log(playerVelocity.x + "," + playerVelocity.z + ", M: " + playerVelocity.magnitude);
        rb.position += playerVelocity;
	}

	private void PerformPlayerRotate ()
	{
        rb.rotation = (rb.rotation * Quaternion.Euler(playerRotation));
	}

	private void PerformCameraRotate ()
	{
        cam.transform.rotation = (cam.transform.rotation * Quaternion.Euler(cameraRotationX));
	}

	private void FixedUpdate ()
	{
        if (playerVelocity != Vector3.zero)
        {
            PeformPlayerMove();
        }
        if (playerRotation != Vector3.zero)
        {
            PerformPlayerRotate();
        }
        if (cameraRotationX != Vector3.zero)
        {
            PerformCameraRotate();
        }     
	}	
}
