using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScrollScript : MonoBehaviour
{
    private RectTransform rectTransform;

    public bool isScroll;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    
    private void Update()
    {
        if(isScroll == true)
        {
            if(rectTransform.position.y < Screen.height / 2.0f)
            {
                rectTransform.position = new Vector3(rectTransform.position.x, rectTransform.position.y + Screen.height / 1960.0f, rectTransform.position.z);
            }
        }
    }
}
