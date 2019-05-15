using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBehav : MonoBehaviour {
    public bool isPaused;
    public GameObject pause;
	// Use this for initialization
	void Start () {
        isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused || Input.GetKeyDown(KeyCode.Joystick1Button7) && !isPaused || Input.GetKeyDown(KeyCode.Joystick2Button7) && !isPaused)
        {
            pause.SetActive(true);
            PauseGame();
        }
       else if (Input.GetKeyDown(KeyCode.Escape) && isPaused || Input.GetKeyDown(KeyCode.Joystick1Button7) && isPaused || Input.GetKeyDown(KeyCode.Joystick2Button7) && isPaused)
        {
            pause.SetActive(false);
            PauseGame();
            
        }

    }

    public  void PauseGame()
    {
        if (!isPaused)
        {
            
            Time.timeScale = 0;
            isPaused = !isPaused;
        }
        else if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = !isPaused;
        }
    }
}
