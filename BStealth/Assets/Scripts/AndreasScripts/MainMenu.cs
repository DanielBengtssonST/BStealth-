using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject controls, main, levels;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Controls()
    {
        controls.SetActive(true);
        main.SetActive(false);
    }

    public void Level(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Levels()
    {
        levels.SetActive(true);
        main.SetActive(false);
    }

    public void Back()
    {
        levels.SetActive(false);
        controls.SetActive(false);
        main.SetActive(true);
    }
}
