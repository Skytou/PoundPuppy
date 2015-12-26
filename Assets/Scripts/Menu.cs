using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

	
	void Start ()
    {
        Time.timeScale = 1f;

	}
	
	
	void Update ()
    {
	
	}

    public void LetsPlay()
    {
        Application.LoadLevel("Combo");
    }

    public void MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
