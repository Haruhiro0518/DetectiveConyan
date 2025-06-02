using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform transform;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public Rigidbody2D rigidbody;

    public AudioSource jumpSE;
    public AudioSource damageSE;

    public GameObject groundChecker;
    private GroundCheckerScript groundCheckerScript;

    public GameObject mainSystem;
    private MainSystemScript mainSystemScript;

    public float moveSpeed;
    public float moveDirection;
    public float jumpSpeed;
    
    public Vector3 respawnPosition;

    private bool isMove;
    private bool isJump;
    public bool isFlip;
    public bool isDamage;

    private void Start()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        groundCheckerScript = groundChecker.GetComponent<GroundCheckerScript>();
        mainSystemScript = mainSystem.GetComponent<MainSystemScript>();
        isMove = false;
        isJump = false;
        isFlip = false;
    }

    private void Update()
    {
        if(mainSystemScript.isPause != true && mainSystemScript.isClear != true && mainSystemScript.isOver != true)
        {
            Move();
            Jump();
            AnimationCheck();
            PositionCheck();
        }
        else
        {
            Stop();
        }
    }

    private void Move()
    {
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            isMove = true;
            isFlip = false;
            moveDirection = 1.0f;
        }

        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            isMove = false;
            moveDirection = 0.0f;
        }

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isMove = true;
            isFlip = true;
            moveDirection = -1.0f;
        }

        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isMove = false;
            moveDirection = 0.0f;
        }

        rigidbody.velocity = new Vector3(moveDirection * moveSpeed, rigidbody.velocity.y, 0.0f);
    }

    private void Jump()
    {
        isJump = groundCheckerScript.isJump;
        
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(isJump != true)
            {
                if(mainSystemScript.isReverse != true)
                {
                    rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpSpeed, 0.0f);
                }
                else
                {
                    rigidbody.velocity = new Vector3(rigidbody.velocity.x, -jumpSpeed, 0.0f);
                }

                jumpSE.Play();
            }
        }
    }

    private void Stop()
    {
        rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        jumpSE.Stop();
    }

    private void AnimationCheck()
    {
        spriteRenderer.flipX = isFlip;
        animator.SetBool("isMove", isMove);
        animator.SetBool("isJump", isJump);
    }

    private void PositionCheck()
    {
        if(transform.position.y < -8.0f)
        {
            mainSystemScript.isOver = true;
        }
    }

    public IEnumerator Damage()
    {
        damageSE.Play();
        isDamage = true;
        for(int i = 0; i < 10; i++)
        {
            spriteRenderer.color = new Color32(255, 0, 0, 255);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color32(255, 255, 255, 255);
            yield return new WaitForSeconds(0.1f);
        }
        isDamage = false;
    }

    public void ResetPosition()
    {
        transform.position = respawnPosition;
    }
}
