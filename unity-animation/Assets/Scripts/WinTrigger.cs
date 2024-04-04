using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text timerText; // Reference to the timer text component
    public float increasedFontSize = 60f; // Increased font size when the player wins
    public Color winColor = Color.green; // Color when the player wins
    public Timer timerObject;

    private void OnTriggerEnter(Collider other)
    {

            // Increase font size and change color of the timer text
            if (timerText != null)
            {
                timerText.fontSize = (int)increasedFontSize;
                timerText.color = winColor;
                timerObject.gameObject.SetActive(false);
            }
    }
}