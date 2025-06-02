using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenTitleScript : MonoBehaviour
{
    private RectTransform rectTransform;
    
    public GameObject titleSystem;
    private TitleSystemScript titleSystemScript;

    public bool isWait;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        titleSystemScript = titleSystem.GetComponent<TitleSystemScript>();
    }

    private void Update()
    {
        if(titleSystemScript.isLoad == true)
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
                titleSystemScript.LoadEnd();
            }
        }
    }
}
