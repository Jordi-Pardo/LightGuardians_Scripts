using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerCountdown : MonoBehaviour {

    public Text timeText;
    public float TimeStamp;
    public bool usingTimer = false;

 

    void Start()
    {
        SetTimer(300f);
    }

    private void Update()
    {
        if (usingTimer)
            SetUIText();
    }
    public void SetTimer (float time)
    {
        if (usingTimer)
            return;

        TimeStamp = Time.time + time;
        usingTimer = true;
    }

    public void SetUIText()
    {
        float timeLeft = TimeStamp - Time.time;
        if (timeLeft <= 0)
        {
            FinishAction();
            return;
        }
        float hours;
        float minutes;
        float seconds;
        float miliseconds;
        GetTimeValues(timeLeft, out hours, out minutes, out seconds, out miliseconds);
        if (hours > 0)
        {
            timeText.text = string.Format("{0}:{1}", hours, minutes);

        }
        else if (minutes > 0)
        {
            timeText.text = string.Format("{0}:{01}:{2}", minutes, seconds,miliseconds);
        }
        else
            timeText.text = string.Format("{0}:{1}:{2}",minutes, seconds, miliseconds);
    }

    public void GetTimeValues(float time, out float hours, out float minutes, out float seconds, out float miliseconds)
    {
        hours = (int)(time / 3600f);
        minutes = (int)((time - hours * 3600) / 60f);
        seconds = (int)((time - hours * 3600 - minutes * 60));
        miliseconds = (int)((time - hours * 3600 - minutes * 60 - seconds) * 100);

    }

    public void FinishAction()
    {
        SceneManager.LoadScene(4);
        Debug.Log("It's Time");
        timeText.text = "00:00";
        usingTimer = false;
    }
}

