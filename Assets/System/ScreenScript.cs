using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScript : MonoBehaviour
{
    private RectTransform rectTransform;
    
    public GameObject mainSystem;
    private MainSystemScript mainSystemScript;

    public bool isWait;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        mainSystemScript = mainSystem.GetComponent<MainSystemScript>();
    }

    private void Update()
    {
        if(mainSystemScript.isLoad == true)
        {
            if(rectTransform.position.y > Screen.height / 2.0f)
            {
                rectTransform.position = new Vector3(rectTransform.position.x, rectTransform.position.y - Screen.height / 120.0f, rectTransform.position.z);
            }
            else
            {
                isWait = true;
            }
        }
        else
        {
            if(rectTransform.position.y < Screen.height * 3.0f / 2.0f)
            {
                rectTransform.position = new Vector3(rectTransform.position.x, rectTransform.position.y + Screen.height / 120.0f, rectTransform.position.z);
            }
            else
            {
                isWait = false;
                mainSystemScript.LoadEnd();
            }
        }
    }
}
