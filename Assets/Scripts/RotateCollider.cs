using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCollider : MonoBehaviour
{
    [SerializeField]
    GameObject targetPosition;
    [SerializeField]
    GameObject planetContainer;
    [SerializeField]
    private float movementSpeed = 10;
    [SerializeField]
    GameObject frontCollider;
    [SerializeField]
    GameObject backCollider;
    [SerializeField]
    GameObject leftCollider;
    [SerializeField]
    GameObject rightCollider;

    void Start(){
        targetPosition = GameObject.FindGameObjectWithTag("UpIndicator");
        planetContainer = GameObject.FindGameObjectWithTag("PlanetContainer");
        frontCollider = GameObject.FindGameObjectWithTag("FrontCollider");
        backCollider = GameObject.FindGameObjectWithTag("BackCollider");
        leftCollider = GameObject.FindGameObjectWithTag("LeftCollider");
        rightCollider = GameObject.FindGameObjectWithTag("RightCollider");
    }
    void Update () {
        // Draw a ray pointing at our target in
        // Debug.DrawRay(transform.position, , Color.red);
        // Debug.Log(gameObject.name+ " global roation: " + transform.rotation.eulerAngles);
    }
    void OnTriggerEnter(Collider other)
    {   
        if (other.tag == "Player"){
            // flip planet with this face as top
            // Debug.Log("Collision with player detected on face " + gameObject.name);
            
            // Determine which direction to rotate towards
            Vector3 targetDirection = Vector3.up;

            // Debug.Log("transform: "+transform.rotation.eulerAngles);
            
            float x_difference = transform.rotation.eulerAngles.x;
            float z_difference = transform.rotation.eulerAngles.z;

            if(x_difference >= 180){
                x_difference = x_difference - 360;
            }else if(x_difference <= -180){
                x_difference = x_difference + 360;
            }

            if(z_difference >= 180){
                z_difference = z_difference - 360;
            }else if(z_difference <= -180){
                z_difference = z_difference + 360;
            }

            StartCoroutine(RotateWorld(-x_difference, -z_difference));

            // rotate itself and the opposite one
            // GameObject collider1 = null;
            // GameObject collider2 = null;

            // if(gameObject.tag == "FrontCollider" || gameObject.tag == "BackCollider"){
            //     collider1 = leftCollider;
            //     collider2 = rightCollider;
            // }

            // if(gameObject.tag == "LeftCollider" || gameObject.tag == "RightCollider"){
            //     collider1 = frontCollider;
            //     collider2 = backCollider;
            // }

            // collider1.transform.Rotate(
            //     -x_difference, 
            //     0, 
            //     -z_difference, 
            //     Space.World);

            // collider2.transform.Rotate(
            //     -x_difference, 
            //     0, 
            //     -z_difference, 
            //     Space.World);
        }
    }
    [SerializeField]
    float timeToRotate = 5f;
    IEnumerator RotateWorld(float x_rotation, float z_rotation) {
        float elapsedTime = 0.0f;
        
        Vector3 targetVector = new Vector3(
                planetContainer.transform.rotation.eulerAngles.x+x_rotation,
                planetContainer.transform.rotation.eulerAngles.y, 
                planetContainer.transform.rotation.eulerAngles.z+z_rotation
                );

        Debug.Log("Target vector.x: "+targetVector.x);
        Debug.Log("Target vector.y: "+targetVector.y);
        Debug.Log("Target vector.z: "+targetVector.z);
        
        Quaternion targRot =  Quaternion.Euler(
            targetVector
            );
        
        Quaternion startingRotation = planetContainer.transform.rotation;

        Debug.Log("Rotation: "+x_rotation+" "+z_rotation);
        Debug.Log("Starting rotation: "+startingRotation.eulerAngles);
        Debug.Log("Starting rotation: "+startingRotation);
        Debug.Log("Target rotation: "+targRot.eulerAngles);
        Debug.Log("Target rotation: "+targRot);

        while (elapsedTime < timeToRotate) {
            elapsedTime += Time.deltaTime; // <- move elapsedTime increment here
            
            planetContainer.transform.rotation = Quaternion.Slerp(startingRotation, targRot,  (elapsedTime / timeToRotate)  );

            yield return new WaitForEndOfFrame ();
        }
        
        StopCoroutine("RotateWorld");
    }
}
