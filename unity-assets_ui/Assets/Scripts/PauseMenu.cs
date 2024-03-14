using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
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
        OptionsMenu.previousSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Options");
        Time.timeScale = 1f;
    }
}

public static class OptionsMenu
{
    public static int previousSceneIndex; // Define previousSceneIndex here
}