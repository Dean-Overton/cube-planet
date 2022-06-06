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
    //Default rotation
    Quaternion targetOrientation = Quaternion.Euler(Vector3.zero);
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //TODO: Slerp towards target orientation
        transform.rotation = targetOrientation;

        if(horizontalInput < 0){
            //update the position
            targetPosition = transform.position+Vector3.left;
            targetOrientation = Quaternion.Euler(0,90,0);
        } else if(horizontalInput > 0){
            //update the position
            targetPosition = transform.position+Vector3.right;
            targetOrientation = Quaternion.Euler(0,-90,0);
        } else if(verticalInput > 0){
            //update the position
            targetPosition = transform.position+Vector3.forward;
            targetOrientation = Quaternion.Euler(0,180,0);
        } else if(verticalInput < 0){
            //update the position
            targetPosition = transform.position+Vector3.back;
            targetOrientation = Quaternion.Euler(Vector3.zero);
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime*movementSpeed);
    }
}
