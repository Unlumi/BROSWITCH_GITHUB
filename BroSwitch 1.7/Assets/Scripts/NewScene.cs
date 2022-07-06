using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
    private int nextSceneToLoad;

    public string currentScene;

    public CharacterSwitching CharacterSwitching;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().name == "Level_2")
        {
            CharacterSwitching.switchedToRightCharacter = false;
        } else if (SceneManager.GetActiveScene().name == "Level_5")
        {
            CharacterSwitching.switchedToRightCharacter = false;
        }

        SceneManager.LoadScene(nextSceneToLoad);

        if (currentScene == "Level_1")
        {
            CharacterSwitching.firstTimeLoadingLevel = true;
        } else if (currentScene == "Level_2")
        {
            CharacterSwitching.firstTimeLoadingLevel = true;
        } else if (currentScene == "Level_3")
        {
            CharacterSwitching.firstTimeLoadingLevel = true;
        } else if (currentScene == "Level_4")
        {
            CharacterSwitching.firstTimeLoadingLevel = true;
        } else if (currentScene == "Level_5")
        {
            CharacterSwitching.firstTimeLoadingLevel = true;
        }

    }
}
