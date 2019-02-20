using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Button ButtonStartGame;
    public Button ButtonExitGame;
    public string newGameSceneName;

    public void StartGame()
    {
        SceneManager.LoadScene(newGameSceneName);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
