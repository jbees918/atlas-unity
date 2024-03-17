using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public Timer timerScript; // Reference to the Timer script

    // Ensure the timer continues running even if the player respawns
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger activated");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player has started");
            timerScript.gameObject.SetActive(true);

        }
    }
}
