using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{

    public GameObject PanelMenu;
	void Start ()
    {
        Time.timeScale = 1f;
        PanelMenu.SetActive(true);

	}
	
	
	void Update ()
    {
	
	}

    public void LetsPlay()
    {
        PanelMenu.SetActive(false);
    }

    public void ShowMenu()
    {
        PanelMenu.SetActive(true);
    }
}
