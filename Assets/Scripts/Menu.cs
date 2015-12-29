using UnityEngine;
using UnityEngine.Analytics;
using System.Collections;

public class Menu : MonoBehaviour
{

    public GameObject PanelMenu;
	void Start ()
    {
        Time.timeScale = 1f;
        PanelMenu.SetActive(true);



	}
	
	
	 
    public void LetsPlay()
    {
		//UnityADManager.instance.ShowAd();
		SoundManager.instance.PlaySfx(SFXVAL.buttonClick);
        PanelMenu.SetActive(false);
    }

    public void ShowMenu()
    {
		SoundManager.instance.PlaySfx(SFXVAL.buttonClick);
        PanelMenu.SetActive(true);
    }

	public void ShowLeaderBoard()
	{
		SoundManager.instance.PlaySfx(SFXVAL.buttonClick);
		GooglePlayServiceManager.instance.ShowLeaderBoard();
	}

	public void ShowAchievements()
	{
		SoundManager.instance.PlaySfx(SFXVAL.buttonClick);
		GooglePlayServiceManager.instance.ShowAchievements();
	}
}
