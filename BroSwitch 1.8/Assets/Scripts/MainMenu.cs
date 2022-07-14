using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Base", LoadSceneMode.Additive);
    }

    public void quitGame()
    {
        print("you quit the game");
        Application.Quit();
    }
}
