using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
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

		Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
	}

	public void LoadBannerAd()
	{
		BannerLoadOptions options = new BannerLoadOptions()
		{
			loadCallback = BannerLoaded,
			errorCallback = BannerLoadedError
		};

		Advertisement.Banner.Load(adUnitID, options);
	}

	public void ShowBannerAd()
	{
		BannerOptions options = new BannerOptions()
		{
			showCallback = BannerShown,
			clickCallback = BannerClicked,
			hideCallback = BannerHidden
		};

		Advertisement.Banner.Show(adUnitID, options);
	}

	public void HideBannerAd()
	{
		Advertisement.Banner.Hide();
	}

	private void BannerHidden()
	{
	}

	private void BannerClicked()
	{
	}

	private void BannerShown()
	{
	}

	private void BannerLoadedError(string message)
	{
	}

	private void BannerLoaded()
	{
		
	}
}
