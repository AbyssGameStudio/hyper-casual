using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Upgrader : MonoBehaviour
{

	[SerializeField] GameObject leftUpgrader;
	[SerializeField] GameObject rightUpgrader;

    [SerializeField] private TextMeshPro m_TextRightHeader;
	[SerializeField] private TextMeshPro m_TextRightFooter;

	[SerializeField] private TextMeshPro m_TextLeftHeader;
	[SerializeField] private TextMeshPro m_TextLeftFooter;

	[SerializeField] private string[] upgrades = { "Thrust" , "Aileron" , "Elevator" , "Hydraulics" , "Wings" , "Agility" };

	[SerializeField] private Material red;
	[SerializeField] private Material green;


	public int upgradeLeftFooter;
	public int upgradeRightFooter;

	public string upgradeLeftHeader;
	public string upgradeRightHeader;

	private void Awake()
	{
		DecideUpgrade();
	}
	private void DecideUpgrade()
	{
		
		upgradeLeftHeader = upgrades.RandomIndex().ToString();
		
		upgradeRightHeader = upgrades.RandomIndex().ToString();	

		m_TextLeftHeader.text = upgradeLeftHeader;
		m_TextRightHeader.text = upgradeRightHeader;

		upgradeLeftFooter = UnityEngine.Random.Range(0, 11);
		upgradeRightFooter = UnityEngine.Random.Range(0, 11);

		
		m_TextLeftFooter.text = upgradeLeftFooter.ToString();
		m_TextRightFooter.text = upgradeRightFooter.ToString();
	

		var possibilityRight = UnityEngine.Random.Range(0, 3);
		var possibilityLeft = UnityEngine.Random.Range(0, 3);

		if (possibilityRight == 0 || possibilityRight == 1)
		{
			rightUpgrader.GetComponent<Renderer>().material = green;
		}
		else
		{
			rightUpgrader.GetComponent<Renderer>().material = red;
			upgradeRightFooter *= -1;

			
			m_TextRightFooter.text = upgradeRightFooter.ToString();

		}

		if (possibilityLeft == 0 || possibilityLeft == 1)
		{
			leftUpgrader.GetComponent<Renderer>().material = green;
		}
		else
		{
			leftUpgrader.GetComponent<Renderer>().material = red;
			upgradeLeftFooter *= -1;

			m_TextLeftFooter.text = upgradeLeftFooter.ToString();
			
		}

	}



}

