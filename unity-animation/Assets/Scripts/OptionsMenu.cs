using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Toggle invertYToggle;

    private bool previousInvertedState;

    private void Start()
    {
        // Load the previous inverted state if available
        previousInvertedState = PlayerPrefs.GetInt("InvertedState", 0) == 1;
        invertYToggle.isOn = previousInvertedState;
    }

    public void Apply()
    {
        // Save the inverted state
        PlayerPrefs.SetInt("InvertedState", invertYToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();

        // Return to the previous scene
        SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene"));
    }

    public void Back()
    {
        // Return to the previous scene without saving changes
        SceneManager.LoadScene(PlayerPrefs.GetString("PreviousScene"));
    }
}