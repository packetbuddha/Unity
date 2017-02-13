using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter1 
{
	public class Enemy : MonoBehaviour {

		[SerializeField] private int numEnemy;
		[SerializeField] private GameObject enemyPrefab;
		private Vector3 spawnPoint;
		private Rigidbody enemyInstanceRB;

		void SpawnEnemy () 
		{
			for (int i = 0; i < numEnemy; i++) {
				float enemyX = Random.Range(1.0f, 10.0f);
				float enemyZ = Random.Range(1.0f, 10.0f);
				spawnPoint = new Vector3(enemyX, 1, enemyZ);

				GameObject enemyInstance = (GameObject) Instantiate(enemyPrefab, spawnPoint, transform.rotation);
				enemyInstanceRB = enemyInstance.GetComponent<Rigidbody>();
			}
		}

		// Use this for initialization
		void Start () 
		{
			SpawnEnemy();
		}
		
		// Update is called once per frame
		void Update () 
		{
			
		}
	}

}
