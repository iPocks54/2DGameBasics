using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject player;
    public bool right;
    float randX;
    Vector2 posSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    Vector2 pos;
    float offset = 15;
    void Start()
    {
        pos = player.transform.position;

        if (!right)
            offset = -15;
    }

    void Update()
    {
        pos = player.transform.position;
        transform.position = new Vector3(pos.x, 0, -10);

        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(pos.x + offset, pos.x + (offset * 2));
            posSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy, posSpawn, Quaternion.identity);
        }
    }
}
