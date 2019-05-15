using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipTutorial : MonoBehaviour {
    public GameObject panel;
    public bool mandoSelected;
    public GameObject fade;
    public GameBehav gameBehav;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            panel.SetActive(false);

        }
	}

    public void ChosenController()
    {
        gameBehav.mandoSelected = true;
        mandoSelected = true;

        PlayerPrefs.SetInt("optionSelected", 1);
    }
    public void ChosenKeyboard()
    {
        PlayerPrefs.SetInt("optionSelected", 2);
        mandoSelected = false;

        gameBehav.mandoSelected = false;
    }
}
