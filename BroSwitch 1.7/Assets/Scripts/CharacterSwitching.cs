using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterSwitching : MonoBehaviour
{
    public float BigJumpHeight;
    public float SmallJumpHeight;
    public float sizeChanges;

    private string charakter;

    public bool switchedToRightCharacter;
    public static bool firstTimeLoadingLevel = true;

    public GameObject IsGrounded;
    public GameObject Player;
    public HeadHitting HeadHitting;
    private PlayerMovement PlayerMovement;
    public TextMeshProUGUI SizeChangesAmount;
    public PlayerDeath PlayerDeath;
    public ParticleSystem SmallToBig;
    public ParticleSystem BigToSmall;
    public AudioSource SwitchingSound;



    private void Start()
    {   
        if (SceneManager.GetActiveScene().name == "Level_1")
        {
            sizeChanges = 2;
        }
        else if (SceneManager.GetActiveScene().name == "Level_2")
        {
            sizeChanges = 3;
        }
        else if (SceneManager.GetActiveScene().name == "Level_3")
        {
            sizeChanges = 2;

        } else if (SceneManager.GetActiveScene().name == "Level_4")
        {
            sizeChanges = 5;

        } else if (SceneManager.GetActiveScene().name == "Level_5")
        {
            sizeChanges = 6;
        }
        else if (SceneManager.GetActiveScene().name == "Level_6")
        {
            sizeChanges = 7;
            
        } 
    }

    private void Update()
    {

        SizeChangesAmount.text = sizeChanges.ToString();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (sizeChanges != 0)
            {
                SwitchCharakter();
                SwitchingSound.Play();
                sizeChanges -= 1;
            }
        }

        if (SceneManager.GetActiveScene().name == "Level_3" && switchedToRightCharacter == false)
        {
            charakter = "Small";

            Player.GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.4f);

            IsGrounded.GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.2f);

            PlayerMovement.jumpHeight = SmallJumpHeight;

            Player.GetComponent<Animator>().SetInteger("BigOrSmall", 0);

            switchedToRightCharacter = true;
        } else if (SceneManager.GetActiveScene().name == "Level_5" && switchedToRightCharacter == false)
        {
            charakter = "Small";

            Player.GetComponent<BoxCollider2D>().size = new Vector2(0.4f, 0.4f);

            IsGrounded.GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.2f);

            PlayerMovement.jumpHeight = SmallJumpHeight;

            Player.GetComponent<Animator>().SetInteger("BigOrSmall", 0);

            switchedToRightCharacter = true;
        }
    }

    // FUNCTIONS________________________________________________________________

    private void SwitchCharakter()
    {
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
