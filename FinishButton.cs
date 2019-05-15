using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishButton : MonoBehaviour {

    public GameObject message,messageKeyBoard;
    public bool canPress;
    public GameObject finalPanel;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
        if (canPress)
        {
			if (Input.GetKeyDown(KeyCode.F) && Input.GetKeyDown(KeyCode.Keypad1) && PlayerPrefs.GetInt("optionSelected") == 2)
            {
                finalPanel.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Joystick1Button1) && Input.GetKeyDown(KeyCode.Joystick2Button1) && PlayerPrefs.GetInt("optionSelected") == 1)
            {
                finalPanel.SetActive(true);
            }
        }
		
	}
    private void OnTriggerEnter(Collider other)
    {

        if (PlayerPrefs.GetInt("optionSelected") == 1)
        {
            if (other.tag == "Player" || other.tag == "Player2")
            {
                message.SetActive(true);
                canPress = true;
            }
        }

        if (PlayerPrefs.GetInt("optionSelected") == 2)
        {
            if (other.tag == "Player" || other.tag == "Player2")
            {
                messageKeyBoard.SetActive(true);
                canPress = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (PlayerPrefs.GetInt("optionSelected") == 1)
        {
            if (other.tag == "Player" || other.tag == "Player2")
            {
                message.SetActive(false);
                canPress = false;
            }
        }

        if (PlayerPrefs.GetInt("optionSelected") == 2)
        {
            if (other.tag == "Player" || other.tag == "Player2")
            {
                messageKeyBoard.SetActive(false);
                canPress = false;
            }
        }
    }
}
