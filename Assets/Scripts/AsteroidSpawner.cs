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

        int randomIndex = Random.Range(0, myObjects.Length);
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));
    
        Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
    }
}
