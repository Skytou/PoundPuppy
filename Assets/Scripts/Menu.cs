using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using System.Collections;

public class Menu : MonoBehaviour
{
    public static ComboManager instRef;
    public GameObject PanelMenu;

	public Image sound;
	public Sprite soundOn, soundOff;


	public Image p_sound;
	 

	void Start ()
    {
        Time.timeScale = 1f;
        PanelMenu.SetActive(true);

		if(GlobalVariables.isMuted)
		{
			sound.sprite = soundOff;
			p_sound.sprite = soundOff;

		}
		else
		{
			sound.sprite = soundOn;
			p_sound.sprite = soundOn;
		}


	}
	
	
	 
    public void LetsPlay()
    {
		//UnityADManager.instance.ShowAd();
		SoundManager.instance.PlaySfx(SFXVAL.buttonClick);
        PanelMenu.SetActive(false);
        ComboManager.instRef.listenForStart = true;
        ComboManager.instRef.OnReset();

    }

    public void ShowMenu()
    {
		SoundManager.instance.PlaySfx(SFXVAL.buttonClick);
		EventMgr.OnGameResume();
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


	public void MuteSound()
	{
		if(GlobalVariables.isMuted)
		{
			GlobalVariables.isMuted = false;
			sound.sprite = soundOn;
			p_sound.sprite = soundOn;

		}
		else
		{
			GlobalVariables.isMuted = true;
			sound.sprite = soundOff;
			p_sound.sprite = soundOff;
		}
	}


	void Update()
	{
		Debug.Log(GlobalVariables.isMuted);
	}
}
