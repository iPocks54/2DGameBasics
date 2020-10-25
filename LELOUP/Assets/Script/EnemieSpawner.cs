using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemieSpawner : MonoBehaviour
{

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;

    public float spawnRate1 = 2f;
    private float baseSpawnRate1;

    public float spawnRate2 = 12f;
    private float baseSpawnRate2;

    public float spawnRate3 = 30f;
    private float baseSpawnRate3;

    public float spawnRate4 = 15f;
    private float baseSpawnRate4;

    Score s;
    public GameObject player;
    private float score;
    int right;
    float randX;
    Vector2 posSpawn;

    float nextSpawn1 = 0.0f;
    float nextSpawn2 = 0.0f;
    float nextSpawn3 = 0.0f;
    float nextSpawn4 = 0.0f;

    Vector2 pos;
    float offset = 15;
    int[] direction = new int[2];
    int index = 0;
    void Start()
    {
        pos = player.transform.position;

        direction[0] = -1;
        direction[1] = 1;

        GameObject text = GameObject.Find("Score");
        s = text.GetComponent<Score>();

        baseSpawnRate1 = spawnRate1;
        baseSpawnRate2 = spawnRate2;
        baseSpawnRate3 = spawnRate3;
        baseSpawnRate4 = spawnRate4;

    }

    void Update()
    {
        pos = player.transform.position;
        transform.position = new Vector3(pos.x, 0, -10);

        SpawnEnemy1();
        SpawnEnemy2();
        SpawnEnemy3();
        SpawnEnemy4();

        score = s.score;

        index = Random.Range(0, direction.Length);
        right = direction[index];

    }


    void SpawnEnemy1()
    {
        if (spawnRate1 > 1)
            spawnRate1 = baseSpawnRate1 - (score / 4000);

        if (Time.time > nextSpawn1)
        {
            nextSpawn1 = Time.time + spawnRate1;
            randX = Random.Range(pos.x + offset * right, pos.x + (offset * right * 2));
            posSpawn = new Vector2(randX, enemy1.transform.position.y);
            Instantiate(enemy1, posSpawn, Quaternion.identity);
        }
    }

    void SpawnEnemy2()
    {
        if (spawnRate2 > 7)
            spawnRate2 = baseSpawnRate2 - (score / 3000);

        if (Time.time > nextSpawn2 && score > 100)
        {
            nextSpawn2 = Time.time + spawnRate2;
            randX = Random.Range(pos.x + offset, pos.x + (offset * 2));
            posSpawn = new Vector2(randX * right, enemy2.transform.position.y);
            Instantiate(enemy2, posSpawn, Quaternion.identity);
        }
    }

    void SpawnEnemy3()
    {
        if (spawnRate3 > 10)
            spawnRate3 = baseSpawnRate3 - (score /2500);

        if (Time.time > nextSpawn3 && score > 500)
        {
            nextSpawn3 = Time.time + spawnRate3;
            randX = Random.Range(pos.x + offset, pos.x + (offset * 2));
            posSpawn = new Vector2(randX * right, enemy3.transform.position.y);
            Instantiate(enemy3, posSpawn, Quaternion.identity);
        }
    }

    void SpawnEnemy4()
    {
        if (spawnRate4 > 10)
            spawnRate4 = baseSpawnRate4 - (score / 3500);

        if (Time.time > nextSpawn4 && score > 250)
        {
            nextSpawn4 = Time.time + spawnRate4;
            randX = Random.Range(pos.x + offset, pos.x + (offset * 2));
            posSpawn = new Vector2(randX * right, enemy4.transform.position.y);
            Instantiate(enemy4, posSpawn, Quaternion.identity);
        }
    }
}
