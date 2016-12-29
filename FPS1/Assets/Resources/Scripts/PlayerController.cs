using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(ConfigurableJoint))]

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float lookSensitivity = 3f;

    [SerializeField]
    private float thrusterForce = 1000;

    [Header("Spring Settings:")]
    [SerializeField]
    private float jointSpring = 20f;
    [SerializeField]
    private float jointMaxForce = 40f;


    private PlayerMotor motor;
    private ConfigurableJoint joint;

	void Start () 
	{
		motor = GetComponent<PlayerMotor>();
        joint = GetComponent<ConfigurableJoint>();

        SetJointSettings(jointSpring);
	}

	void Update ()
	{
		// Calculate movement velocity as 3D Vector

        // Get -1, 0 or 1 value for movement
		float _xMov = Input.GetAxisRaw("Horizontal");
		float _zMov = Input.GetAxisRaw("Vertical");

        // Get vector using the object-local direction (transform.xxx) * movment direction
		Vector3 _movHorizontal = transform.right * _xMov;
		Vector3 _movVertical = transform.forward * _zMov;

		// Final velocity vector
		Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

		motor.Move(_velocity); 

		// Calculate rotation as a 3D vector
		float _yRot = Input.GetAxisRaw("Mouse X");

		// Final rotation vector
		Vector3 _playerRotationY = new Vector3(0f, _yRot, 0f) * lookSensitivity;

		motor.Rotate(_playerRotationY);

		// Calculate camera rotation
		float _xRot = Input.GetAxisRaw("Mouse Y");

		float _cameraRotationX = _xRot * lookSensitivity;

		// Apply camera rotation
		motor.CameraRotation(_cameraRotationX);

        // Calculate thruster force based on user input
        Vector3 _thrusterForce = Vector3.zero;
        if (Input.GetButton("Jump"))
        {
            // vector3.up refers to 'up' related to world-space
            _thrusterForce = Vector3.up * thrusterForce;
 
            SetJointSettings(0);
        } else
        {
            SetJointSettings(jointSpring);
        }
        // Apply thruster force
        motor.ApplyThruster(_thrusterForce);
    }

    private void SetJointSettings(float _jointSpring)
    {
        joint.yDrive = new JointDrive
        {
            positionSpring = _jointSpring,
            maximumForce = jointMaxForce
        };
    }
}
