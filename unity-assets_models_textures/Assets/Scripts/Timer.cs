using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    public float startTime;
    public bool timerRunning;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        timerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            float elapsedTime = Time.time - startTime;

            // Formatting time into minutes, seconds, and milliseconds
            string minutes = ((int)elapsedTime / 60).ToString("00");
            string seconds = (elapsedTime % 60).ToString("00");
            string milliseconds = ((elapsedTime * 100) % 100).ToString("00");

            // Update the timer text
            TimerText.text = minutes + ":" + seconds + "." + milliseconds;
        }
    } 
    public void StartTimer()
    {
        startTime = Time.time;
        timerRunning = true;
    }
}
