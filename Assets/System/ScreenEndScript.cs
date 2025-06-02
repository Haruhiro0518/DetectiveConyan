using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEndScript : MonoBehaviour
{
    private RectTransform rectTransform;
    
    public GameObject endSystem;
    private EndSystemScript endSystemScript;

    public bool isWait;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        endSystemScript = endSystem.GetComponent<EndSystemScript>();
    }

    private void Update()
    {
        if(endSystemScript.isLoad == true)
        {
            if(rectTransform.position.y > Screen.height / 2.0f)
            {
                rectTransform.position = new Vector3(rectTransform.position.x, rectTransform.position.y - Screen.height / 120.0f, rectTransform.position.z);
            }
            else
            {
                isWait = true;
                
                if(endSystemScript.isTitle != true)
                {
                    endSystemScript.TextEnd();
                    endSystemScript.isLoad = false;
                }
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
                endSystemScript.LoadEnd();
            }
        }
    }
}
