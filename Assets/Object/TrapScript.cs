using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public GameObject mainSystem;
    private MainSystemScript mainSystemScript;
    
    private void Start()
    {
        mainSystemScript = mainSystem.GetComponent<MainSystemScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            mainSystemScript.SetOver();
        }
    }
}
