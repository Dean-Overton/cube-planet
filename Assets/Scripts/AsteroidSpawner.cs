using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] objectsToSpawn;

    public Queue<GameObject> spawnedObjects = new Queue<GameObject>();

    // Update is called once per frame
    void Update()
    {
        // some sort of wait method
        if(Random.Range(0, 100) == 5){
            int randomIndex = Random.Range(0, objectsToSpawn.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), Random.Range(-20, 20));
            GameObject ast = Instantiate(objectsToSpawn[randomIndex], randomSpawnPosition, Quaternion.identity);
            
            spawnedObjects.Enqueue(ast);

            if(spawnedObjects.Count >= 5){
                GameObject oldAst = spawnedObjects.Dequeue();
                Destroy(oldAst);
            }

            Rigidbody rb = ast.GetComponent<Rigidbody>();
            Vector3 randomForce = new Vector3(Random.Range(-10, 20), Random.Range(-10, 20), Random.Range(-10, 20));

            rb.AddForce(randomForce, ForceMode.Impulse);
        }
    }
}
