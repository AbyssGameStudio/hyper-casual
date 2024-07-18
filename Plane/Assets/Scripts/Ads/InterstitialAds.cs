using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitalAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
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

	public void LoadInterstitialAd()
	{
		Advertisement.Load(adUnitID, this);

	}

	public void ShowInterstitialAd()
	{
		Advertisement.Show(adUnitID, this);
		LoadInterstitialAd();
	}

	public void OnUnityAdsAdLoaded(string placementId)
	{
		Debug.Log("Interstital Ad loaded");
	}

	#region ShowCallbacks
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
		Debug.Log("Interstital Ad complete");
		Time.timeScale = 1;

	}
	#endregion
}
