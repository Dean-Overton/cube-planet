using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPlane : MonoBehaviour
{   
    [SerializeField]
    GameObject planetContainer;

    [SerializeField] private float _rollSpeed = 5;
    private bool _isMoving;

    void Start(){
        planetContainer = GameObject.FindGameObjectWithTag("PlanetContainer");
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isMoving){
            Assemble(Vector3.left);
        }
    }

    void Assemble(Vector3 dir) {
        Vector3 anchor = planetContainer.transform.position;
        Vector3 axis = Vector3.Cross(Vector3.forward, dir);
        
        StartCoroutine(Roll(anchor, axis));
    }

    private IEnumerator Roll(Vector3 anchor, Vector3 axis) {
        Debug.Log("Rolling");
        _isMoving = true;
        for (int i = 0; i < 90 / _rollSpeed; i++) {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        _isMoving = false;
    }
}
