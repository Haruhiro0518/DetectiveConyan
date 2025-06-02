using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckerScript : MonoBehaviour
{
    public bool isJump;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            isJump = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            isJump = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            isJump = true;
        }
    }
}
