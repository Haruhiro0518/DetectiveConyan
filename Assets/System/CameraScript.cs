using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{   
    private Transform transform;
    public AudioSource BGM;
    public AudioSource answerTrueSE;
    public AudioSource answerFalseSE;
    
    public GameObject target;
    private PlayerScript targetScript;
    private Transform targetTransform;
    
    public Vector3 offset;
    
    private void Start()
    {
        transform = GetComponent<Transform>();
        targetScript = target.GetComponent<PlayerScript>();
        targetTransform = target.GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        if(targetScript.isFlip != true && offset.x < 4.0f)
        {
            offset.x = offset.x + 0.1f;
        }

        if(targetScript.isFlip == true && offset.x > -4.0f)
        {
            offset.x = offset.x - 0.1f;
        }
        
        transform.position = new Vector3(targetTransform.position.x + offset.x, offset.y, offset.z);
        
    }
}
