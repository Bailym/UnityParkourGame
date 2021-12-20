using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;  //the timer text object
    float currentTime;  //the current value for the timer
    bool timerActive = false;   //whether the timer is active or not.
    TimeSpan time;  //a Timespan for the timer value

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;    //set timer to 0
    }

    // Update is called once per frame
    void Update()
    {
        //update timer when active
        if(timerActive == true)
        {
            currentTime += Time.deltaTime;
        }

        //convert to timespan
         time = TimeSpan.FromSeconds(currentTime);
        
        //individual timespan values
        string mins = time.Minutes.ToString("D2");
        string seconds = time.Seconds.ToString("D2");
        string mills = time.Milliseconds.ToString("D3");

        //update UI text
        timerText.text = mins + ":" + seconds + ":" + mills;
    }

    public void startTimer()
    {
        timerActive = true; //start the timer
    }

    public void stopTimer()
    {
        timerActive = false;    //stop timer

        string currentHighScore = PlayerPrefs.GetString("Level" + SceneManager.GetActiveScene().buildIndex + "Score", "None");  //the current high score from playerprefs

        float highScoreSeconds; //current high score in seconds.

        //if there is a high score, work out the seconds.
        if (currentHighScore != "None")
        {
            highScoreSeconds = (Convert.ToInt32(currentHighScore.Substring(0, 2)) * 60) + (Convert.ToInt32(currentHighScore.Substring(3, 2))) + ((float)(Convert.ToInt32(currentHighScore.Substring(6, 3)) / 1000f));
        }
        //otherwise set to the max value (so that any score will become the new high score)
        else
        {
            highScoreSeconds = float.MaxValue;
        }
        

        print(currentHighScore);    //DEBUG
        print(highScoreSeconds);
        print(time.TotalSeconds);

        //if the time is faster than the current high score 
        if(time.TotalSeconds < highScoreSeconds)
        {
            print("new high score!");
            PlayerPrefs.SetString("Level" + SceneManager.GetActiveScene().buildIndex + "Score", timerText.text);
        }
    }
}
