using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityADManager : MonoBehaviour {


	public static UnityADManager instance;



	void Awake()
	{
		instance = this;
		if (Advertisement.isSupported) 
		{
			Advertisement.Initialize ("1024877");
		} 
		else 
		{
			Debug.Log("Platform not supported");
		}
	}

	// Use this for initialization
	void Start () 
	{
	
	}

	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}

	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log("The ad was successfully shown.");
			//
			// YOUR CODE TO REWARD THE GAMER
			// Give coins etc.
			ComboManager.instRef.ResetValueAfterContinueAD();
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}
	// Update is called once per frame
	void Update () 
	{
	
	}
}

 
 