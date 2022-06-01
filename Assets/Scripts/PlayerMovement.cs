using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    [SerializeField]
    private float movementSpeed = 1;

    private void Start()
    {
        targetPosition = transform.position;
    }
    Vector3 targetPosition;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            //update the position
            targetPosition = transform.position+Vector3.left;
        }
        else if(Input.GetKeyDown(KeyCode.W)){
            //update the position
            targetPosition = transform.position+Vector3.forward;
        }
        else if(Input.GetKeyDown(KeyCode.S)){
            //update the position
            targetPosition = transform.position+Vector3.back;
        }
        else if(Input.GetKeyDown(KeyCode.D)){
            //update the position
            targetPosition = transform.position+Vector3.right;
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime*movementSpeed);
    }
}
