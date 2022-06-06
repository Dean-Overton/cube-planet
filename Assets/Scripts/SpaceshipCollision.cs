using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipCollision : MonoBehaviour
{
    [SerializeField]
    bool takeOff = false;
    [SerializeField]
    int speed = 5;

    void OnTriggerEnter(Collider other){          
        if (other.tag == "Player"){
            if(LevelController.Instance.checkWin()){
                Destroy(other.gameObject);
                takeOff = true;
            }
        }
    }

    void Update(){
        if(takeOff){
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
    }
}
