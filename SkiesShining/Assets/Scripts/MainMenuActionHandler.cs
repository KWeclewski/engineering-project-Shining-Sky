using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuActionHandler : MonoBehaviour
{
    public bool showing = false;
    public GameObject credits;
    public GameObject options;

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadGame()
    {
        string filename = Path.Combine(Application.persistentDataPath, "SaveGame.json");

        if (File.Exists(filename))
        {
            LoadGameStatic loadGame = new LoadGameStatic();
            LoadGameStatic.LoadGame = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void Options()
    {
        if (!options.activeSelf && !showing)
        {
            options.SetActive(true);
            showing = true;
        }else if (options.activeSelf && showing)
        {
            options.SetActive(false);
            showing = false;
        }
    }
    public void Credits()
    {
        if (!credits.activeSelf && !showing)
        {
            credits.SetActive(true);
            showing = true;
        }else if (credits.activeSelf && showing)
        {
            credits.SetActive(false);
            showing = false;
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}