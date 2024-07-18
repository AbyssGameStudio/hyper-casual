using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Upgrader;
	[SerializeField] private GameObject Obstacle;
	[SerializeField] private Vector3 upgraderSpawnPosition = new Vector3 (5.81f, 0.47f, 100f);
    [SerializeField] private float upgraderSpawnTime = 1f;
	[SerializeField] private float obstaclePossibility = 50;

	[SerializeField] private GameObject planeLevel1;
	[SerializeField] private GameObject planeLevel3;
	[SerializeField] private GameObject planeLevel4;
	[SerializeField] private GameObject planeLevel5;
	[SerializeField] private GameObject planeLevel6;

	[SerializeField] private Vector3 spawnPosition = new Vector3(0,-0.3f,-4f);



	void Start()
    {
		


		StartCoroutine(Spawn(upgraderSpawnTime, Upgrader, Obstacle, upgraderSpawnPosition));

		PlayerPrefs.SetInt("Thrust", 0);
		PlayerPrefs.SetInt("Aileron", 0);
		PlayerPrefs.SetInt("Elevator", 0);
		PlayerPrefs.SetInt("Hydraulics", 0);
		PlayerPrefs.SetInt("Wings", 0);
		PlayerPrefs.SetInt("Agility", 0);

		switch (PlayerPrefs.GetInt("PlayerLevel"))
		{
			case 1: { Instantiate(planeLevel1, spawnPosition, Quaternion.identity); break; }
			case 2: { Instantiate(planeLevel3, spawnPosition, Quaternion.identity); break; }
			case 3: { Instantiate(planeLevel4, spawnPosition, Quaternion.identity); break; }
			case 4: { Instantiate(planeLevel5, spawnPosition, Quaternion.identity); break; }
			case 5: { Instantiate(planeLevel6, spawnPosition, Quaternion.identity); break; }

		}

		

	}

	

	private IEnumerator Spawn(float f, GameObject upgrader, GameObject obstacle, Vector3 pos)
    {
		
		while (true)
		{
			float possibility = UnityEngine.Random.Range(0, 80f);

			yield return new WaitForSeconds(f);

			if(possibility >= obstaclePossibility)
			{
				Instantiate(upgrader, pos, Quaternion.identity);

			}
			else
			{
			
				var leftorright = UnityEngine.Random.Range(0, 2);
				if (leftorright == 0)
				{
					Instantiate(obstacle, new Vector3(-1.7f, 0.4f, 80f), Quaternion.identity);
				}
				else
				{
					Instantiate(obstacle, new Vector3(1.4f, 0.4f, 80f), Quaternion.identity);

				}
			}
			//obstaclePossibility += (Mathf.Log10(obstaclePossibility) / obstaclePossibility) * (Mathf.Abs( Mathf.Sin(obstaclePossibility)) * 25);
			obstaclePossibility += 11 / obstaclePossibility;
			Debug.Log(obstaclePossibility);
			upgraderSpawnTime -= Mathf.Log10(f);
		
		}
	}
}
