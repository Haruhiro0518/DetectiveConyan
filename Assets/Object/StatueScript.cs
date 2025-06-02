using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite defaultSprite;
    public Sprite anotherSprite;

    public GameObject questionUI;

    public GameObject mainSystem;
    private MainSystemScript mainSystemScript;

    private bool isAnswer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        mainSystemScript = mainSystem.GetComponent<MainSystemScript>();
        isAnswer = false;
    }

    private void OnMouseEnter()
    {
        if(mainSystemScript.isPause != true && mainSystemScript.isClear != true && mainSystemScript.isOver != true && isAnswer != true)
        {
            spriteRenderer.sprite = anotherSprite;
        }
    }

    private void OnMouseExit()
    {
        if(mainSystemScript.isPause != true && mainSystemScript.isClear != true && mainSystemScript.isOver != true && isAnswer != true)
        {
            spriteRenderer.sprite = defaultSprite;
        }
    }

    private void OnMouseDown()
    {
        if(mainSystemScript.isPause != true && mainSystemScript.isClear != true && mainSystemScript.isOver != true && isAnswer != true)
        {
            questionUI.SetActive(true);
            mainSystemScript.statueSE.Play();
            mainSystemScript.isPause = true;
        }
    }
}
