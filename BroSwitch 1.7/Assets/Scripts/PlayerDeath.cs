using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerDeath : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y <= -10  || Input.GetKey(KeyCode.R))
        {
            PlayerDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Spike")
        {
            PlayerDeath();
        }
    }

    public void PDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene());
    }

}
