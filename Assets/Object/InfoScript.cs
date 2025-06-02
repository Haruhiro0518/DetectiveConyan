using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite defaultSprite;
    public Sprite anotherSprite;

    public GameObject infoUI;

    public GameObject mainSystem;
    private MainSystemScript mainSystemScript;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mainSystemScript = mainSystem.GetComponent<MainSystemScript>();
    }

    private void OnMouseEnter()
    {
        if(mainSystemScript.isPause != true && mainSystemScript.isClear != true && mainSystemScript.isOver != true)
        {
            spriteRenderer.sprite = anotherSprite;
        }
    }

    private void OnMouseExit()
    {
        if(mainSystemScript.isPause != true && mainSystemScript.isClear != true && mainSystemScript.isOver != true)
        {
            spriteRenderer.sprite = defaultSprite;
        }
    }

    private void OnMouseDown()
    {
        if(mainSystemScript.isPause != true && mainSystemScript.isClear != true && mainSystemScript.isOver != true)
        {
            infoUI.SetActive(true);
            mainSystemScript.isPause = true;
            mainSystemScript.infoSE.Play();
        }
    }
}
