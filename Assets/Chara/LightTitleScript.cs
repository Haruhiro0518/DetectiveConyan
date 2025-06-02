using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTitleScript : MonoBehaviour
{
    private Transform transform;

    public GameObject titleSystem;
    private TitleSystemScript titleSystemScript;

    private Vector3 mousePosition;
    
    private void Start()
    {
        transform = GetComponent<Transform>();
        titleSystemScript = titleSystem.GetComponent<TitleSystemScript>();
    }

    private void Update()
    {
        if(titleSystemScript.isPause != true)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }
    }
}
