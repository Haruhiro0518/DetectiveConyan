using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{   
    private Transform transform;

    public GameObject mainSystem;
    private MainSystemScript mainSystemScript;

    private Vector3 mousePosition;
    
    private void Start()
    {
        transform = GetComponent<Transform>();
        mainSystemScript = mainSystem.GetComponent<MainSystemScript>();
    }

    private void Update()
    {
        if(mainSystemScript.isPause != true && mainSystemScript.isOver != true)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }
}
