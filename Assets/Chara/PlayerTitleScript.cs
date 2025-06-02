using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTitleScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Vector3 mousePosition;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(mousePosition.x < 0.0f)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
