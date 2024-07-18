using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCollider : MonoBehaviour
{
	[SerializeField] private Upgrader upgrader;
	[SerializeField] private GameObject prefabFire;
	[SerializeField] private GameObject prefabSpark;
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Touched Left");
		AddValues();
		if (upgrader.upgradeLeftFooter <= 0)
		{
			Instantiate(prefabFire, transform.position, Quaternion.identity);
		}
		else
		{
			Instantiate(prefabSpark, transform.position, Quaternion.identity);

		}

	}

	private void AddValues()
	{
		PlayerPrefs.SetInt(upgrader.upgradeLeftHeader, PlayerPrefs.GetInt(upgrader.upgradeLeftHeader) + upgrader.upgradeLeftFooter);
	}
}
