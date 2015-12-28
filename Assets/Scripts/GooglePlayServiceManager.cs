using UnityEngine;
using Prime31;
using System.Collections;

public class GooglePlayServiceManager : MonoBehaviour 
{
	public static GooglePlayServiceManager instance;


	public string[] achievemnents;



	void Awake()
	{
		instance = this;
	}

	// Use this for initialization
	void Start ()
	{
		//InitCall();	 
	}

	public void InitCall()
	{
		if(!PlayGameServices.isSignedIn())
		PlayGameServices.authenticate();
	}


	public void ShowLeaderBoard()
	{
		Debug.Log("Showing Leaderboard");
		PlayGameServices.showLeaderboard("CgkIr87MtK4BEAIQAA");
	}

	public void ShowAchievements()
	{
		Debug.Log("Showing Achievement");
		PlayGameServices.showAchievements();
	}

	public void UnlockAchievement(string achievementName)
	{
		PlayGameServices.unlockAchievement(achievementName,true);
	}

	// Update is called once per frame
	void Update () 
	{
	
	}
}
