﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	[SerializeField]
	private Camera cam;

	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private Vector3 cameraRotation = Vector3.zero;

	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
	}

	public void Move (Vector3 _velocity )
	{
		velocity = _velocity;
	}

	public void Rotate (Vector3 _rotation )
	{
		rotation = _rotation;
	}

	public void CameraRotation (Vector3 _cameraRotation )
	{
		cameraRotation = _cameraRotation;
	}

	// Runs every physics iteration
	void FixedUpdate ()
	{
		PerformMovement();
		PerformRotation();
	}

	// Perform movement based on velocity vector
	void PerformMovement ()
	{
		if (velocity != Vector3.zero)
		{
			rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);
		}
	}

	// Perform rotation
	void PerformRotation ()
	{
		if (rotation != Vector3.zero) {
			rb.MoveRotation (rb.rotation * Quaternion.Euler (rotation));
			if (cam != null)
			{
				cam.transform.Rotate(-cameraRotation);
			}
		}
	}


}
