using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[SerializeField] private Sprite planeLevel1;
	[SerializeField] private Sprite planeLevel3;
	[SerializeField] private Sprite planeLevel4;
	[SerializeField] private Sprite planeLevel5;
	[SerializeField] private Sprite planeLevel6;

	[SerializeField] private GameObject planeSprite;


	[SerializeField] private TextMeshProUGUI thrust;
	[SerializeField] private TextMeshProUGUI aileron;
	[SerializeField] private TextMeshProUGUI elevator;
	[SerializeField] private TextMeshProUGUI wings;
	[SerializeField] private TextMeshProUGUI agility;
	[SerializeField] private TextMeshProUGUI hydraulics;

	[SerializeField] private TextMeshProUGUI upgradeText;

	[SerializeField] private Button upgradeButton;



	private int m_thrust;
	private int m_aileron;
	private int m_elevator;
	private int m_wings;
	private int m_agility;
	private int m_hydraulics;

	private bool isRewarded = false;

	bool isUpgradeable;
	private void Start()
	{
		PlayerPrefs.SetInt("PlayerLevel", 1);
		StartCoroutine(DisplayBanner());
		
	}


	private IEnumerator DisplayBanner()
	{
		yield return new WaitForSeconds(1f);
		AdsManager.Instance.bannerAds.ShowBannerAd();

	}



	private void Update()
	{
		m_thrust = PlayerPrefs.GetInt("Thrust");
		m_aileron = PlayerPrefs.GetInt("Aileron");
		m_elevator = PlayerPrefs.GetInt("Elevator");
		m_agility = PlayerPrefs.GetInt("Agility");
		m_wings = PlayerPrefs.GetInt("Wings");
		m_hydraulics = PlayerPrefs.GetInt("Hydraulics");

		thrust.text = "Thrust: " + PlayerPrefs.GetInt("Thrust").ToString();
		aileron.text = "Aileron: " + PlayerPrefs.GetInt("Aileron").ToString();
		elevator.text = "Elevator " + PlayerPrefs.GetInt("Elevator").ToString();
		wings.text = "Wings: " + PlayerPrefs.GetInt("Wings").ToString();
		agility.text = "Agility: " + PlayerPrefs.GetInt("Agility").ToString();
		hydraulics.text = "Hydraulics: " + PlayerPrefs.GetInt("Hydraulics").ToString();

		CheckUpgradePlane();
		CheckPlane();
		CheckUpgradeButton();

	}

	private void CheckUpgradePlane()
	{
		if(m_thrust >= 100 && m_aileron >= 100 && m_elevator >= 100 && m_hydraulics >= 100 && m_thrust >= 100 && m_wings >= 100)
		{
			thrust.color = Color.green;
			aileron.color = Color.green;
			agility.color = Color.green;
			wings.color = Color.green;
			elevator.color = Color.green;
			hydraulics.color = Color.green;
			isUpgradeable = true;
			upgradeButton.enabled = true;
		}
		else
		{
			thrust.color = Color.red;
			aileron.color = Color.red;
			agility.color = Color.red;
			wings.color = Color.red;
			elevator.color = Color.red;
			hydraulics.color = Color.red;
			isUpgradeable = false;
			upgradeButton.enabled = false;


		}

	}

	 private void CheckPlane()
	 {
		switch (PlayerPrefs.GetInt("PlayerLevel"))
		{
			case 1: { planeSprite.GetComponent<Image>().sprite = planeLevel1; break; }
			case 2: { planeSprite.GetComponent<Image>().sprite = planeLevel3; break; }
			case 3: { planeSprite.GetComponent<Image>().sprite = planeLevel4; break; }
			case 4: { planeSprite.GetComponent<Image>().sprite = planeLevel5; break; }
			case 5: { planeSprite.GetComponent<Image>().sprite = planeLevel6; break; }

		}

	 }

	private void CheckUpgradeButton()
	{
		if (isUpgradeable)
		{
			upgradeText.text = "You can upgrade your plain by pressing the button!";
			upgradeText.color = Color.green;
		}
		else
		{
			upgradeText.text = "Earn more parts to upgrade your plane!";
			upgradeText.color = Color.red;
		}
	}
}
