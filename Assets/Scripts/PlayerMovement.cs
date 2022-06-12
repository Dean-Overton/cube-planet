using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    [SerializeField]
    private float movementSpeed = 1;
    [SerializeField] private FloatingJoystick _joystick;
    Vector3 targetPosition;
    //Default rotation
    Quaternion targetOrientation = Quaternion.Euler(Vector3.zero);
    private Animator _anim;

    private void Awake() {
        _anim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        targetPosition = transform.position;
        _joystick = GameObject.FindObjectOfType<FloatingJoystick>();
    }

    void Update()
    {
        Vector3 direction = Vector3.forward * _joystick.Vertical + Vector3.right * _joystick.Horizontal;

#if UNITY_EDITOR
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
#else
        float horizontalInput = _joystick.Horizontal;
        float verticalInput = _joystick.Vertical;

        horizontalInput = Mathf.Abs(verticalInput) > Mathf.Abs(horizontalInput) ? 0 : horizontalInput;
        verticalInput = Mathf.Abs(verticalInput) < Mathf.Abs(horizontalInput) ? 0 : verticalInput;
#endif

        //TODO: Slerp towards target orientation
        transform.rotation = targetOrientation;

        if(horizontalInput < 0){
            //update the position
            targetPosition = transform.position+Vector3.left;
            targetOrientation = Quaternion.Euler(0,90,0);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime*movementSpeed);

        } else if(horizontalInput > 0){
            //update the position
            targetPosition = transform.position+Vector3.right;
            targetOrientation = Quaternion.Euler(0,-90,0);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime*movementSpeed);
        } else if(verticalInput > 0){
            //update the position
            targetPosition = transform.position+Vector3.forward;
            targetOrientation = Quaternion.Euler(0,180,0);
            
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime*movementSpeed);

        } else if(verticalInput < 0){
            //update the position
            targetPosition = transform.position+Vector3.back;
            targetOrientation = Quaternion.Euler(Vector3.zero);
           
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime*movementSpeed);
        }

        if (Mathf.Abs(horizontalInput) > 0 || Mathf.Abs(verticalInput) > 0) {
            _anim.SetBool("isWalking", true);
        } else {
             _anim.SetBool("isWalking", false);
        }
    }
}
