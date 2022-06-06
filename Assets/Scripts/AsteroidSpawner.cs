using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] myObjects;

    // Update is called once per frame
    void Update()
    {
        // some sort of wait method
        if(Random.Range(0, 100) == 5){
            int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
            GameObject ast = Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);

            Rigidbody rb = ast.GetComponent<Rigidbody>();
            Vector3 randomForce = new Vector3(Random.Range(-10, 20), Random.Range(-10, 20), Random.Range(-10, 20));

            rb.AddForce(randomForce, ForceMode.Impulse);
        }
    }
}
