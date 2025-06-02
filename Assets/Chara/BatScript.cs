using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    private Transform transform;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rigidbody;

    public GameObject mainSystem;
    private MainSystemScript mainSystemScript;

    public int movePattern;
    public float moveSpeed;
    public float moveAngle;
    public Vector3 movePositionBefore;
    public Vector3 movePositionAfter;
    private bool isTurn;
    private bool isFlip;
    private bool isWait;
    private bool isCollide;
    
    private void Start()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        mainSystemScript = mainSystem.GetComponent<MainSystemScript>();
        isTurn = false;
        isFlip = false;
        isWait = false;
        isCollide = false;
    }

    private void Update()
    {
        if(mainSystemScript.isPause != true && mainSystemScript.isClear != true && mainSystemScript.isOver != true)
        {
            Move();
            AnimationCheck();
        }
        else
        {
            Stop();
        }
    }

    private void Move()
    {
        switch(movePattern)
        {
            case 0:
            {
                if(isWait != true)
                {
                    if(isTurn != true)
                    {
                        if(transform.position.x > movePositionAfter.x)
                        {
                            isFlip = false;
                            rigidbody.velocity = new Vector3(-moveSpeed, 0.0f, 0.0f);
                        }
                        else
                        {
                            StartCoroutine(Wait());
                        }
                    }
                    else
                    {
                        if(transform.position.x < movePositionBefore.x)
                        {
                            isFlip = true;
                            rigidbody.velocity = new Vector3(moveSpeed, 0.0f, 0.0f);
                        }
                        else
                        {
                            StartCoroutine(Wait());
                        }
                    }
                }
                else
                {
                    Stop();
                }

                break;
            }
            case 1:
            {
                if(isWait != true)
                {
                    if(isTurn != true)
                    {
                        if(transform.position.y > movePositionAfter.y)
                        {
                            rigidbody.velocity = new Vector3(0.0f, -moveSpeed, 0.0f);
                        }
                        else
                        {
                            StartCoroutine(Wait());
                        }
                    }
                    else
                    {
                        if(transform.position.y < movePositionBefore.y)
                        {
                            rigidbody.velocity = new Vector3(0.0f, moveSpeed, 0.0f);
                        }
                        else
                        {
                            StartCoroutine(Wait());
                        }
                    }
                }
                else
                {
                    Stop();
                }

                break;
            }
            case 2:
            {
                float x = (movePositionAfter.x + movePositionBefore.x) / 2.0f + Mathf.Cos(moveAngle) * (movePositionAfter.x - movePositionBefore.x) / 2.0f;
                float y = (movePositionAfter.y + movePositionBefore.y) / 2.0f + Mathf.Sin(moveAngle) * (movePositionAfter.y - movePositionBefore.y) / 2.0f;

                moveAngle = moveAngle + moveSpeed * Time.deltaTime;
                transform.position = new Vector3(x, y, 0.0f);

                if(transform.position.y < ((movePositionAfter.y + movePositionBefore.y) / 2.0f))
                {
                    isFlip = true;
                }
                if(transform.position.y > ((movePositionAfter.y + movePositionBefore.y) / 2.0f))
                {
                    isFlip = false;
                }

                break;
            }
        }
    }

    private void Stop()
    {
        rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }

    private void AnimationCheck()
    {
        spriteRenderer.flipX = isFlip;
    }

    private IEnumerator Wait()
    {
        isWait = true;
        yield return new WaitForSeconds(1.0f);
        isTurn = !isTurn;
        isWait = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(isCollide != true)
            {
                mainSystemScript.TimePenalty();
                StartCoroutine(DisablePenalty());
            }
        }
    }

    private IEnumerator DisablePenalty()
    {
        isCollide = true;
        yield return new WaitForSeconds(2.0f);
        isCollide = false;
    }
}
