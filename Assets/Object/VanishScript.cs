using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishScript : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite anotherSprite;

    private SpriteRenderer[] childSpriteRenderers;
    private Collider2D[] childColliders;

    public float timeVanish;
    
    private bool isVanish;
    
    private void Start()
    {
        childSpriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        childColliders = GetComponentsInChildren<Collider2D>();
        isVanish = false;
    }

    private void Update()
    {
        if(isVanish != true)
        {
            foreach(SpriteRenderer spriteRenderer in childSpriteRenderers)
            {
                spriteRenderer.enabled = true;
            }
            foreach (Collider2D collider in childColliders)
            {
                collider.enabled = true;
            }
        }
        else
        {
            foreach(SpriteRenderer spriteRenderer in childSpriteRenderers)
            {
                spriteRenderer.enabled = false;
            }
            foreach (Collider2D collider in childColliders)
            {
                collider.enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(isVanish != true)
            {
                StartCoroutine(Wait());
            }
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeVanish);

        for(int i = 0; i < 10; i++)
        {
            foreach(SpriteRenderer spriteRenderer in childSpriteRenderers)
            {
                spriteRenderer.sprite = anotherSprite;
            }
            yield return new WaitForSeconds(0.1f);
            foreach(SpriteRenderer spriteRenderer in childSpriteRenderers)
            {
                spriteRenderer.sprite = defaultSprite;
            }
            yield return new WaitForSeconds(0.1f);
        }

        isVanish = true;
        yield return new WaitForSeconds(4.0f);
        isVanish = false;
    }
}
