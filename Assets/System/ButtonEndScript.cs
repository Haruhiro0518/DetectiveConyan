using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEndScript : MonoBehaviour
{
    public GameObject targetUI;

    public GameObject endSystem;
    private EndSystemScript endSystemScript;

    private void Start()
    {
        endSystemScript = endSystem.GetComponent<EndSystemScript>();
    }

    public void SelectTitle()
    {
        endSystemScript.LoadTitle();
    }
}
