using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject controls, main;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Controls()
    {
        controls.SetActive(true);
        main.SetActive(false);
    }

    public void HardcoreLevel3()
    {
        SceneManager.LoadScene(5);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Back()
    {
        controls.SetActive(false);
        main.SetActive(true);
    }
}
