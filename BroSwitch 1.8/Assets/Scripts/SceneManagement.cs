using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private int nextSceneIndex;
    private string activeScene;

    private float transitionTime;

    private Animator LvlTransition;

    private GameObject Player;

    void Start()
    {
        Debug.Log("STARTED GAME");

        Player = GameObject.FindGameObjectWithTag("Player");

        if(SceneManager.GetActiveScene().name == "End")
        {
            SceneManager.UnloadSceneAsync("Base");
            Debug.Log("UNLOAD BASE");
        }

        LvlTransition = GameObject.FindWithTag("LvlTransition").GetComponent<Animator>();

        transitionTime = 0.8f;

        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        activeScene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && activeScene != "Menu")
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        Player.GetComponent<Animator>().SetTrigger("Teleport");

        StartCoroutine(LoadLevel());

        Debug.Log("NEXTLEVEL FUNCTION");
    }

    IEnumerator LoadLevel()
    {
        LvlTransition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(nextSceneIndex);
        SceneManager.LoadScene("Base", LoadSceneMode.Additive);

        Debug.Log("IENUMERATOR");

    }
}
