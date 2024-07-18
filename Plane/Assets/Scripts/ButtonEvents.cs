using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
	[SerializeField] private GameObject pauseMenu;

	public void StartGame()
    {
		AdsManager.Instance.bannerAds.HideBannerAd();
		Time.timeScale = 0;
		AdsManager.Instance.interstitalAds.ShowInterstitialAd();
		SceneManager.LoadScene("SampleScene");

	}

	public void UpgradePlane()
    {
        PlayerPrefs.SetInt("PlayerLevel", PlayerPrefs.GetInt("PlayerLevel") + 1);

		PlayerPrefs.SetInt("Thrust", PlayerPrefs.GetInt("Thrust") - 100);
		PlayerPrefs.SetInt("Aileron", PlayerPrefs.GetInt("Aileron") - 100);
		PlayerPrefs.SetInt("Elevator", PlayerPrefs.GetInt("Elevator") - 100);
		PlayerPrefs.SetInt("Wings", PlayerPrefs.GetInt("Wings") - 100);
		PlayerPrefs.SetInt("Hydraulics", PlayerPrefs.GetInt("Hydraulics") - 100);
		PlayerPrefs.SetInt("Agility", PlayerPrefs.GetInt("Agility") - 100);
	}

	public void PauseGame()
	{
		pauseMenu.SetActive(true);
		Time.timeScale = 0;
	}

	public void ContunieGame()
	{
		StartGame();
		
	}

	public void MainMenu()
	{
		AdsManager.Instance.interstitalAds.ShowInterstitialAd();
		SceneManager.LoadScene("UI");
	}

	public void Reward()
	{
		AdsManager.Instance.rewardedAds.ShowRewardedAd();
	}
}
