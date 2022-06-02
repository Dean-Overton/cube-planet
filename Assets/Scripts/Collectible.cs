using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {   
        if (!other.CompareTag("Player")) return;
        
        // trigger 'collection'
        // deletes the object
        Destroy(gameObject);

        // increase a counter in UI
        LevelController.Instance.addBarrel();
    }
}
