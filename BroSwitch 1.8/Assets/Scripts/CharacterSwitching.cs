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


    // Raycast Variable Declaration
    public Transform LeftRayPoint;
    public Transform RightRayPoint;

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
            Player.transform.position = new Vector2(-8.6f, -3.19f);
        }
        else if (SceneManager.GetActiveScene().name == "Level_2")
        {
            Switches = 3;
            SwitchToBig(false);
            Player.transform.position = new Vector2(-9.11f, 0.83f);
        }
        else if (SceneManager.GetActiveScene().name == "Level_3")
        {
            Switches = 2;
            SwitchToSmall(false);
            Player.transform.position = new Vector2(-7.55f, 2.36f);

        }
        else if (SceneManager.GetActiveScene().name == "Level_4")
        {
            Switches = 5;
            SwitchToBig(false);
            Player.transform.position = new Vector2(-8.52f, 0.74f);

        }
        else if (SceneManager.GetActiveScene().name == "Level_5")
        {
            Switches = 6;
            SwitchToSmall(false);
            Player.transform.position = new Vector2(-8.52f, 1.385f);
        }
        else if (SceneManager.GetActiveScene().name == "Level_6")
        {
            Switches = 8;
            SwitchToSmall(false);
            Player.transform.position = new Vector2(-8.52f, 1.385f);

        }
        else if (SceneManager.GetActiveScene().name == "Level_7")
        {
            Switches = 6;
            SwitchToSmall(false);
            Player.transform.position = new Vector2(-8.52f, -3.6f);

        }
        else if (SceneManager.GetActiveScene().name == "Level_8")
        {
            Switches = 3;
            SwitchToBig(false);
            Player.transform.position = new Vector2(-8.515f, 1.745f);

        }
        else if (SceneManager.GetActiveScene().name == "Level_9")
        {
            Switches = 2;
            SwitchToSmall(false);
            Player.transform.position = new Vector2(-8.5f, -3.27f);

        }


        SwitchText.text = Switches.ToString();
    }

    private void Update()
    {
        // Variable Declarations


        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && Switches > 0)
        {
            
            SwitchCharakter();
            
        }
    }

    // FUNCTIONS________________________________________________________________

    private void SwitchCharakter()
    {
        if (charakter == "Big")
        {
            SwitchToSmall(true);

            SwitchingSound.Play();
            Switches -= 1;
            SwitchText.text = Switches.ToString();
        }
        else if (CheckSpace())
        {
            SwitchToBig(true);

            SwitchingSound.Play();
            Switches -= 1;
            SwitchText.text = Switches.ToString();
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

    private bool CheckSpace()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(LeftRayPoint.position, Vector2.up);
        RaycastHit2D rightHit = Physics2D.Raycast(RightRayPoint.position, Vector2.up);
        
        if(leftHit.distance >= 1 && rightHit.distance >= 1)
        {
            // Can Switch
            return true;

        } else
        {
            // Can NOT Switch
            return false;
        }
    }
}