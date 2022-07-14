using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerStay2D(Collider2D other)
    {
        Player.GetComponent<PlayerMovement>().isGrounded = true;
    } 

    private void OnTriggerExit2D(Collider2D other)
    {
        Player.GetComponent<PlayerMovement>().isGrounded = false;
    } 
}
