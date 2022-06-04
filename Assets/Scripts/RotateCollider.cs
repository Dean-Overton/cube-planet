using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCollider : MonoBehaviour
{
    [SerializeField]
    GameObject targetPosition;
    [SerializeField]
    GameObject planetContainer;

    [SerializeField] private float _rollSpeed = 5;
    private bool _isMoving;

    void Start(){
        targetPosition = GameObject.FindGameObjectWithTag("UpIndicator");
        planetContainer = GameObject.FindGameObjectWithTag("PlanetContainer");
    }

    void OnTriggerEnter(Collider other)
    {   
        if (other.tag == "Player"){
            if(gameObject.tag == "LeftCollider"){
                Assemble(Vector3.right);
            }
            if(gameObject.tag == "RightCollider"){
                Assemble(Vector3.left);
            }
            if(gameObject.tag == "FrontCollider"){
                Assemble(Vector3.forward);
            }
            if(gameObject.tag == "BackCollider"){
                Assemble(Vector3.back);
            }
        }
    }

    void Assemble(Vector3 dir) {
        Vector3 anchor = planetContainer.transform.position;
        Vector3 axis = Vector3.Cross(Vector3.up, dir);
        
        // triggers level controller to track the rotations 
        LevelController.Instance.addRotation();
        
        StartCoroutine(Roll(anchor, axis));
    }

    private IEnumerator Roll(Vector3 anchor, Vector3 axis) {
        Debug.Log("Rolling");
        _isMoving = true;
        for (int i = 0; i < 90 / _rollSpeed; i++) {
            planetContainer.transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        _isMoving = false;
    }
}
