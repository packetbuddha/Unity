using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	[SerializeField]
	private Camera cam;

    private Vector3 thrusterForce = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private Vector3 playerRotationY = Vector3.zero;
    private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;



    [SerializeField]
    private float cameraRotationLimit = 85f;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void Move (Vector3 _velocity )
	{
		velocity = _velocity;
	}

	public void Rotate (Vector3 _playerRotationY )
	{
		playerRotationY = _playerRotationY;
	}

	public void CameraRotation (float _cameraRotationX )
	{
		cameraRotationX = _cameraRotationX;
	}

    public void ApplyThruster (Vector3 _thrusterForce)
    {
        thrusterForce = _thrusterForce;
    }

	// Runs every physics iteration
	void FixedUpdate ()
	{
		PerformMovement();
		PerformRotation();
	}

    // Perform movement based on velocity vector
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
        if (thrusterForce != Vector3.zero)
        {
            // ForceMode.Acceleration causes acceleration to be constant, ignoring mass
            rb.AddForce(thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }

	// Perform rotation
	void PerformRotation ()
	{
		if (playerRotationY != Vector3.zero) {
            // MoveRotation requires Quaternion and performs interpolation
            // rb.rotation is the currently rotation as a Quaternion
            // Quaternion.Euler returns A rotation that rotates euler.z degrees around the z axis, euler.x degrees around the x axis, and euler.y degrees around the y axis
            //
            // So we take in a [-1,0,1] movement * speed value, then create a Quaternion based on the euler angles, multiplied by the current rotation Quaternion
            // results in a target rotation as a Quaternion.
            // We then pass that value to MoveRotation to smooth out the animation using interpolation
			rb.MoveRotation (rb.rotation * Quaternion.Euler (playerRotationY));
            //Debug.Log("rb.rotation: " + (rb.rotation).ToString());

			if (cam != null)
			{
                // New rotational calculation
                currentCameraRotationX -= cameraRotationX;
                currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

                cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
			}
		}
	}


}
