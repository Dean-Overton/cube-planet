using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipCollision : MonoBehaviour
{
    [SerializeField]
    bool _takeOff = false;
    [SerializeField]
    bool _landing = true;
    [SerializeField]
    int _speed = 5;
    [SerializeField] Vector3 landingPoint;
    [SerializeField] GameObject _player;
    GameObject _exhaust;

    void Start(){
        // dynamically lets you place a rocket which will land
        // and spawn the player
        // NOTE: the player still needs to be place around the rocket
        // somewhere in the scene
        _player=GameObject.FindGameObjectWithTag("Player");
        _player.SetActive(false);
        
        _exhaust = GameObject.Find("Exhaust");

        // saves current point as the landing point
        landingPoint = transform.position;
        
        // starts the rocket 10 units on the y axis
        // above where it is placed
        transform.position += new Vector3(0, 10, 0);
    }

    void OnTriggerEnter(Collider other){          
        if (other.tag == "Player"){
            if(LevelController.Instance.checkWin()){
                Destroy(other.gameObject);
                _takeOff = true;
            }
        }
    }

    void Update(){
        if(Vector3.Distance(transform.position, landingPoint) < 0.1){
            _landing = false;
            _player.SetActive(true);
            _exhaust.SetActive(false);
        }
        
        if(_landing){
            // note the negative y value means the rocket is coming down
            transform.position += new Vector3(0, -_speed * Time.deltaTime, 0);
        }

        if(_takeOff){
            // flies up
            transform.position += new Vector3(0, _speed * Time.deltaTime, 0);
            _exhaust.SetActive(true);
        }
    }
}
