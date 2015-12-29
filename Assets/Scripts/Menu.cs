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
        PanelMenu.SetActive(false);
    }

    public void ShowMenu()
    {
        PanelMenu.SetActive(true);
    }

	public void ShowLeaderBoard()
	{
		GooglePlayServiceManager.instance.ShowLeaderBoard();
	}

	public void ShowAchievements()
	{
		GooglePlayServiceManager.instance.ShowAchievements();
	}
}
