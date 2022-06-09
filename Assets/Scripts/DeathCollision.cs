using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollision : MonoBehaviour
{   
    void OnTriggerEnter(Collider other){   
        
        if (other.tag == "Player"){
            Destroy(other.gameObject);

            // trigger restart menu
            UIManager.Instance.ShowDeathPopup();
        }
    }
}
