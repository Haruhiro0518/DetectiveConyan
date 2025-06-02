using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour
{
    private Transform transform;
    private Rigidbody2D rigidbody;
    
    public GameObject mainSystem;
    private MainSystemScript mainSystemScript;

    public float moveSpeed;

    public Vector3 movePositionBefore;
    public Vector3 movePositionAfter;

    private bool isTurn;
    private bool isWait;

    private void Start()
    {
        transform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
        mainSystemScript = mainSystem.GetComponent<MainSystemScript>();
        isTurn = false;
        isWait = false;
    }

    private void Update()
    {
        if(mainSystemScript.isPause != true && mainSystemScript.isClear != true && mainSystemScript.isOver != true)
        {
            Move();
        }
        else
        {
            Stop();
        }
    }

    private void Move()
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
    }

    private void Stop()
    {
        rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }

    private IEnumerator Wait()
    {
        isWait = true;
        yield return new WaitForSeconds(1.0f);
        isTurn = !isTurn;
        isWait = false;
    }
}
