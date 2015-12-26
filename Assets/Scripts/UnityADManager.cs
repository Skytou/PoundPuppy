using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityADManager : MonoBehaviour {


	public UnityADManager instance;



	void Awake()
	{
		instance = this;
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
		if (Advertisement.IsReady("rewardedVideoZone"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideoZone", options);
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

 
 