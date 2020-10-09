using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpawner : MonoBehaviour
{

    public GameObject enemy;
    float randX;
    Vector2 posSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-8.4f, 8.4f);
            posSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy, posSpawn, Quaternion.identity);
        }
    }
}
