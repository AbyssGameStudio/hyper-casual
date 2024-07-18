using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
	[SerializeField] private string androidAdUnitID;
	[SerializeField] private string IOSAdUnitID;

	private string adUnitID;

	private void Awake()
	{
		#if UNITY_IOS
						adUnitID = IOSAdUnitID;
		#elif UNITY_ANDROID
				adUnitID = androidAdUnitID;
		#endif
	}

	public void LoadRewardedAd()
	{
		Advertisement.Load(adUnitID, this);

	}

	public void ShowRewardedAd()
	{
		Advertisement.Show(adUnitID, this);
		LoadRewardedAd();
	}

	public void OnUnityAdsAdLoaded(string placementId)
	{
		Debug.Log("Interstital Ad loaded");
	}

	public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
	{
	}

	public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
	{
	}

	public void OnUnityAdsShowStart(string placementId)
	{
	}

	public void OnUnityAdsShowClick(string placementId)
	{
	}

	public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
	{
		Debug.Log("Reward 31");

		

			PlayerPrefs.SetInt("Thrust", PlayerPrefs.GetInt("Thrust") + 5);
			PlayerPrefs.SetInt("Aileron", PlayerPrefs.GetInt("Aileron") + 5);
			PlayerPrefs.SetInt("Elevator", PlayerPrefs.GetInt("Elevator") + 5);
			PlayerPrefs.SetInt("Wings", PlayerPrefs.GetInt("Wings") + 5);
			PlayerPrefs.SetInt("Hydraulics", PlayerPrefs.GetInt("Hydraulics") + 5);
			PlayerPrefs.SetInt("Agility", PlayerPrefs.GetInt("Agility") + 5);

		

	}
}
