using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemieSpawner : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    public float spawnRate1 = 2f;
    private float baseSpawnRate1;

    public float spawnRate2 = 12f;
    private float baseSpawnRate2;

    public float spawnRate3 = 30f;
    private float baseSpawnRate3;

    Score s;
    public GameObject player;
    private float score;
    public bool right;
    float randX;
    Vector2 posSpawn;

    float nextSpawn1 = 0.0f;
    float nextSpawn2 = 0.0f;
    float nextSpawn3 = 0.0f;

    Vector2 pos;
    float offset = 15;
    void Start()
    {
        pos = player.transform.position;

        if (!right)
            offset = -15;

        GameObject text = GameObject.Find("Text");
        s = text.GetComponent<Score>();

        baseSpawnRate1 = spawnRate1;
        baseSpawnRate2 = spawnRate2;
        baseSpawnRate3 = spawnRate3;

    }

    void Update()
    {
        pos = player.transform.position;
        transform.position = new Vector3(pos.x + offset, -2.55f, -10);

        SpawnEnemy1();
        SpawnEnemy2();
        SpawnEnemy3();


        score = s.score;

    }


    void SpawnEnemy1()
    {
        if (spawnRate1 > 1)
            spawnRate1 = baseSpawnRate1 - (score / 4000);

        if (Time.time > nextSpawn1)
        {
            nextSpawn1 = Time.time + spawnRate1;
            randX = Random.Range(pos.x + offset, pos.x + (offset * 2));
            posSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy1, posSpawn, Quaternion.identity);
        }
    }

    void SpawnEnemy2()
    {
        if (spawnRate2 > 7)
            spawnRate2 = baseSpawnRate2 - (score / 3000);

        if (Time.time > nextSpawn2 && score > 250)
        {
            nextSpawn2 = Time.time + spawnRate2;
            randX = Random.Range(pos.x + offset, pos.x + (offset * 2));
            posSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy2, posSpawn, Quaternion.identity);
        }
    }

    void SpawnEnemy3()
    {
        if (spawnRate3 > 10)
            spawnRate3 = baseSpawnRate3 - (score /2500);

        if (Time.time > nextSpawn3 && score > 1000)
        {
            nextSpawn3 = Time.time + spawnRate3;
            randX = Random.Range(pos.x + offset, pos.x + (offset * 2));
            posSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy3, posSpawn, Quaternion.identity);
        }
    }
}
