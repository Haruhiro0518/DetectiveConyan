using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public Sprite defaultSprite;
    public Sprite anotherSprite;
    
    public GameObject player;
    private Transform playerTransform;
    private Rigidbody2D playerRigidbody;

    public GameObject mainSystem;
    private MainSystemScript mainSystemScript;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = player.GetComponent<Transform>();
        playerRigidbody = player.GetComponent<Rigidbody2D>();
        mainSystemScript = mainSystem.GetComponent<MainSystemScript>();
    }

    private void Update()
    {
        if(mainSystemScript.isPause != true && mainSystemScript.isClear != true && mainSystemScript.isOver != true)
        {
            if(mainSystemScript.isReverse != true)
            {
                spriteRenderer.sprite = defaultSprite;
            }
            else
            {
                spriteRenderer.sprite = anotherSprite;
            }
        }
    }

    private void OnMouseEnter()
    {
        if(mainSystemScript.isPause != true && mainSystemScript.isClear != true && mainSystemScript.isOver != true)
        {
            spriteRenderer.color = new Color32(100, 100, 100, 255);
        }
    }

    private void OnMouseExit()
    {
        if(mainSystemScript.isPause != true && mainSystemScript.isClear != true && mainSystemScript.isOver != true)
        {
            spriteRenderer.color = new Color32(255, 255, 255, 255);
        }
    }

    public void OnMouseDown()
    {
        if(mainSystemScript.isPause != true && mainSystemScript.isClear != true && mainSystemScript.isOver != true)
        {
            mainSystemScript.isReverse = !mainSystemScript.isReverse;

            if(mainSystemScript.isReverse != true)
            {
                playerTransform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                playerRigidbody.gravityScale = 2.0f;
            }
            else
            {
                playerRigidbody.gravityScale = -2.0f;
                playerTransform.localScale = new Vector3(1.0f, -1.0f, 1.0f);
            }

            mainSystemScript.switchSE.Play();
        }
    }
}
