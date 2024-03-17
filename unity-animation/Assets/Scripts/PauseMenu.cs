using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static int previousSceneIndex; // Declare previousSceneIndex as static in PauseMenu class
    public GameObject pauseCanvas;
    private bool pressed = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pressed)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pressed)
        {
            Resume();
        }
    }

    public void Pause()
    {
        pressed = true;
        pauseCanvas.SetActive(true); // Activate the PauseCanvas
        Time.timeScale = 0f; // Pause the game
    }

    public void Resume()
    {
        pressed = false;
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false); 
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
        Time.timeScale = 1f; 
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Options()
    {
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex; // Assign value to previousSceneIndex in PauseMenu class
        SceneManager.LoadScene("Options");
        Time.timeScale = 1f;
    }
}