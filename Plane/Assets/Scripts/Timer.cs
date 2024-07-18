using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer: MonoBehaviour
{
	public float timeRemaining = 15;
	public bool timerIsRunning = false;
	[SerializeField] private TextMeshProUGUI timeText;
	[SerializeField] private GameObject timeFinished;

	private void Start()
	{
		// Starts the timer automatically
		timerIsRunning = true;
		timeFinished.SetActive(false);

		StartCoroutine(DisplayBanner());

	}

	private IEnumerator DisplayBanner()
	{
		yield return new WaitForSeconds(1f);
		AdsManager.Instance.bannerAds.ShowBannerAd();

	}

	void Update()
	{
		if (timerIsRunning)
		{
			if (timeRemaining > 0)
			{
				timeRemaining -= Time.deltaTime;
				DisplayTime(timeRemaining);
			}
			else
			{
				Debug.Log("Time has run out!");
				timeRemaining = 0;
				timerIsRunning = false;
				timeFinished.SetActive(true);
				Time.timeScale = 0;
				AdsManager.Instance.bannerAds.HideBannerAd();


			}
		}
	}

	void DisplayTime(float timeToDisplay)
	{
		timeToDisplay += 1;

		float minutes = Mathf.FloorToInt(timeToDisplay / 60);
		float seconds = Mathf.FloorToInt(timeToDisplay % 60);

		timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
	}
}