using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1 
{
	public class Gun : MonoBehaviour {

		public GameObject bulletPrefab;
		public float bulletForce = 100;

		void Shoot () 
		{
			GameObject bulletInstance = (GameObject) Instantiate(bulletPrefab, transform.position, transform.rotation);
			//bulletInstance.velocity = transform.forward * bulletForce;
			bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce, ForceMode.Impulse);
		}
		/*
		void SetInitialReferences () 
		{
			
		}
		*/
		// Update is called once per frame
		void Update ()
		{
			if (Input.GetButtonDown ("Fire1")) 
			{
				Shoot ();
			}
		}
	}

}	
