using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPreTitleScript : MonoBehaviour
{
    private RectTransform rectTransform;
    
    public GameObject preTitleSystem;
    private PreTitleSystemScript preTitleSystemScript;

    public bool isWait;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        preTitleSystemScript = preTitleSystem.GetComponent<PreTitleSystemScript>();
    }

    private void Update()
    {
        if(preTitleSystemScript.isLoad == true)
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
    }
}
