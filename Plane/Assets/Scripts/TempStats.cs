using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TempStats : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI thrust;
	[SerializeField] private TextMeshProUGUI aileron;
	[SerializeField] private TextMeshProUGUI elevator;
	[SerializeField] private TextMeshProUGUI wings;
	[SerializeField] private TextMeshProUGUI agility;
	[SerializeField] private TextMeshProUGUI hydraulics;

	private void Update()
	{
		thrust.text = "Thrust " + PlayerPrefs.GetInt("Thrust").ToString();
		aileron.text = "aileron " + PlayerPrefs.GetInt("Aileron").ToString();
		elevator.text = "Elevator " + PlayerPrefs.GetInt("Elevator").ToString();
		wings.text = "Wings " + PlayerPrefs.GetInt("Wings").ToString();
		agility.text = "Agility " + PlayerPrefs.GetInt("Agility").ToString();
		hydraulics.text = "Hydraulics" + PlayerPrefs.GetInt("Hydraulics").ToString();

	}

}
