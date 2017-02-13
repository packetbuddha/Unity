using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1
{
	public class Treasure : MonoBehaviour {

		[SerializeField]
		private GameObject myLight;
		[SerializeField]
		private GameObject myPlayerCharacter;

		private Camera myCamera;
		private Color lightColorDefault = new Color(1,1,1,1);
		private Color lightColorDanger = new Color(0.1f, 0.1f, 0.1f, 1.0f);
		private Color backgroundColorDanger = new Color(0f, 0f, 0f, 1.0f);
		private float lightIntensityDefault = 1f;
		private float lightIntensityDanger = 2.2f;
		private bool danger = false;

		public delegate void TreasureEvent();
		public static TreasureEvent TreasureTrigger;

		void OnEnable() 
		{
			TreasureTrigger += TreasureStolen;
			TreasureTrigger += DangerMood;
		}

		void OnDisable() 
		{
			TreasureTrigger -= TreasureStolen;
			TreasureTrigger -= DangerMood;
		}

		void Update ()
		{
			if (danger) 
			{
				myCamera.backgroundColor = backgroundColorDanger;
			}
		}
		void GetInitialReferences () 
		{
			myCamera = myPlayerCharacter.GetComponent<Camera>();
		}

		void OnTriggerEnter (Collider col)
		{
			Debug.Log ("trigger!");
			Debug.Log (col.tag);

			if (col.CompareTag ("Player")) 
			{
				TreasureTrigger();
			}
		}

		void DangerMood ()
		{
			myLight.GetComponent<Light>().color = lightColorDanger;
			myLight.GetComponent<Light>().intensity = lightIntensityDanger;

			myCamera.clearFlags = CameraClearFlags.SolidColor;
			danger = true;

		}

		void DefaultMood ()
		{
			myLight.GetComponent<Light>().color = lightColorDefault;
			myLight.GetComponent<Light>().intensity = lightIntensityDefault;
		}

		void TreasureStolen ()
		{
			Destroy(gameObject);
		}


	}

}
