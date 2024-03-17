using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void LevelSelect(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void OptionsButton()
    {
        PlayerPrefs.SetString("previous-scene", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }

    public void ExitButton()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}