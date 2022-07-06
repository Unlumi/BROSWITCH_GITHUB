using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterSwitching : MonoBehaviour
{
    public float BigJumpHeight;
    public float SmallJumpHeight;

    [HideInInspector] public float Switches;

    private string charakter;

    private PlayerMovement PlayerMovement;

    public GameObject IsGrounded;
    public GameObject Player;
    public TextMeshProUGUI SwitchText;
    public ParticleSystem SmallToBig;
    public ParticleSystem BigToSmall;
    public AudioSource SwitchingSound;



    private void Start()
    {
        PlayerMovement = Player.GetComponent<PlayerMovement>();

        if (SceneManager.GetActiveScene().name == "Level_1")
        {
            Switches = 2;
            SwitchToBig();
        }
        else if (SceneManager.GetActiveScene().name == "Level_2")
        {
            Switches = 3;
            SwitchToSmall();
        }
        else if (SceneManager.GetActiveScene().name == "Level_3")
        {
            Switches = 2;
            SwitchToSmall();

        } else if (SceneManager.GetActiveScene().name == "Level_4")
        {
            Switches = 5;
            SwitchToSmall();

        } else if (SceneManager.GetActiveScene().name == "Level_5")
        {
            Switches = 6;
            SwitchToSmall();
        }
        else if (SceneManager.GetActiveScene().name == "Level_6")
        {
            Switches = 7;
            SwitchToSmall();
            
        }

        SwitchText.text = Switches.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Switches > 0)
        {
            
            SwitchCharakter();
            
        }
    }

    // FUNCTIONS________________________________________________________________

    private void SwitchCharakter()
    {
        SwitchingSound.Play();
        Switches -= 1;
        SwitchText.text = Switches.ToString();

        if (charakter == "Small")
        {
            SwitchToBig();
        }
        else
        {
            SwitchToSmall();
        }
    }

    private void SwitchToBig()
    {
        charakter = "Big";

        SmallToBig.Play();

        Player.GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.8f);

        IsGrounded.GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.45f);

        PlayerMovement.jumpHeight = BigJumpHeight;

        Debug.Log(BigJumpHeight);

        Player.GetComponent<Animator>().SetInteger("BigOrSmall", 1);
    }

    private void SwitchToSmall()
    {
        charakter = "Small";

        BigToSmall.Play();

        Player.GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.4f);

        IsGrounded.GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.2f);

        PlayerMovement.jumpHeight = SmallJumpHeight;

        Player.GetComponent<Animator>().SetInteger("BigOrSmall", 0);
    }
}
