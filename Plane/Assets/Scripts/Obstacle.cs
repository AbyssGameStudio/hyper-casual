using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	[SerializeField] private GameObject hitPrefab;
	private void OnTriggerEnter(Collider other)
	{
		//Destroy(other.gameObject);
		//Destroy(other.gameObject);
		Instantiate(hitPrefab, transform.position, Quaternion.identity);

		PlayerPrefs.SetInt("Thrust", PlayerPrefs.GetInt("Thrust") - 10);
		PlayerPrefs.SetInt("Aileron", PlayerPrefs.GetInt("Aileron") - 10);
		PlayerPrefs.SetInt("Elevator", PlayerPrefs.GetInt("Elevator") - 10);
		PlayerPrefs.SetInt("Wings", PlayerPrefs.GetInt("Wings") - 10);
		PlayerPrefs.SetInt("Hydraulics", PlayerPrefs.GetInt("Hydraulics") - 10);
		PlayerPrefs.SetInt("Agility", PlayerPrefs.GetInt("Agility") - 10);



	}
}
