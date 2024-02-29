using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public Timer timerScript; // Reference to the Timer script attached to the player

    // Flag to track if the timer has started
    private bool timerStarted = false;

    // Ensure the timer is only started once
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !timerStarted)
        {
            // Enable the Timer script attached to the player
            timerScript.enabled = true;
            timerStarted = true; // Set the flag to indicate timer has started
        }
    }

    // Ensure the timer continues running even if the player respawns
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset the flag to allow timer to start again if player exits and re-enters trigger
            timerStarted = false;
        }
    }
}
