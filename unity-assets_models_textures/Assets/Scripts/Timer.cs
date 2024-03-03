using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // public GameObject timerTextGameObject; // Reference to the TimerText GameObject
    
    public Text TimerText;
    public float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        if (TimerText == null)
        {
            Debug.LogError("Timer text is not assigned");
        }
    }

    // Update is called once per frame
    void Update()
    {
            float elapsedTime = Time.time - startTime;

            // Formatting time into minutes, seconds, and milliseconds
            string minutes = ((int)elapsedTime / 60).ToString("00");
            string seconds = (elapsedTime % 60).ToString("00");
            string milliseconds = ((elapsedTime * 100) % 100).ToString("00");

            // Update the timer text
            TimerText.text = minutes + ":" + seconds + "." + milliseconds;
    } 
    public void StartTimer()
    {
        startTime = Time.time;
    }
}
