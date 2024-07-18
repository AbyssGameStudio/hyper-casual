using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCollider : MonoBehaviour
{
	[SerializeField] private Upgrader upgrader;
	[SerializeField] private GameObject prefabFire;
	[SerializeField] private GameObject prefabSpark;


	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Touched");
		AddValues();

		if(upgrader.upgradeRightFooter <= 0)
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
		PlayerPrefs.SetInt(upgrader.upgradeRightHeader, PlayerPrefs.GetInt(upgrader.upgradeRightHeader) + upgrader.upgradeRightFooter);
	}
}
