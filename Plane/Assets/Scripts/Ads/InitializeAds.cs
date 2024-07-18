using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class InitializeAds : MonoBehaviour , IUnityAdsInitializationListener
{
    [SerializeField] private string androidGameID;
    [SerializeField] private string IOSGameID;
    [SerializeField] private bool isTesting;

	private string gameID;

	public void OnInitializationComplete()
	{
		Debug.Log("Complete");
	}

	public void OnInitializationFailed(UnityAdsInitializationError error, string message)
	{
		Debug.Log("Not Complete");
	}

	private void Awake()
	{
		#if UNITY_IOS
			gameID = IOSgameID;
		#elif UNITY_ANDROID
				gameID = androidGameID;
		#endif

		if(!Advertisement.isInitialized && Advertisement.isSupported)
		{
			Advertisement.Initialize(gameID, isTesting, this);
		}
	}
}
