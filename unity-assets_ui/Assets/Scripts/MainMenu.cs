using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel1()
    {
        SceneManager.LoadScene("level101");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("level102");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("level103");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
