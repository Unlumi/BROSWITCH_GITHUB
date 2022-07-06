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
            SwitchToBig(false);
        }
        else if (SceneManager.GetActiveScene().name == "Level_2")
        {
            Switches = 3;
            SwitchToBig(false);
        }
        else if (SceneManager.GetActiveScene().name == "Level_3")
        {
            Switches = 2;
            SwitchToSmall(false);

        } else if (SceneManager.GetActiveScene().name == "Level_4")
        {
            Switches = 5;
            SwitchToBig(false);

        } else if (SceneManager.GetActiveScene().name == "Level_5")
        {
            Switches = 6;
            SwitchToSmall(false);
        }
        else if (SceneManager.GetActiveScene().name == "Level_6")
        {
            Switches = 7;
            SwitchToSmall(false);
            
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
            SwitchToBig(true);
        }
        else
        {
            SwitchToSmall(true);
        }
    }

    private void SwitchToBig(bool fx)
    {
        if (fx)
        {
            SmallToBig.Play();
        }

        charakter = "Big";

        Player.GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.8f);

        IsGrounded.GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.45f);

        PlayerMovement.jumpHeight = BigJumpHeight;

        Player.GetComponent<Animator>().SetInteger("BigOrSmall", 1);
    }

    private void SwitchToSmall(bool fx)
    {
        if (fx)
        {
            BigToSmall.Play();
        }

        charakter = "Small";

        Player.GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.4f);

        IsGrounded.GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.2f);

        PlayerMovement.jumpHeight = SmallJumpHeight;

        Player.GetComponent<Animator>().SetInteger("BigOrSmall", 0);
    }
}
