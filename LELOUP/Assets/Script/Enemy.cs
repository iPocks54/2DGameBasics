using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int deathScore = 0;
    int currentHealth;
    public GameObject[] loots;
    public int[] lootsProb;
    Transform pos;
    int direction = 1;

    void Start()
    {
        currentHealth = maxHealth;
        pos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int damage)
    {
        if (transform.position.x - pos.position.x < 0)
            direction = -1;
        else
            direction = 1;

        currentHealth -= damage;
        GetComponent<Rigidbody2D>().velocity = new Vector2(5 * direction, 0);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (Random.Range(0, lootsProb[0]) == 1)
            DropLoot(0);
        if (Random.Range(0, lootsProb[1]) == 1)
            DropLoot(1);
        if (Random.Range(0, lootsProb[2]) == 1)
            DropLoot(2);
        GameObject[] score = GameObject.FindGameObjectsWithTag("Score");
        if (score.Length != 0)
            score[0].GetComponent<Score>().score += deathScore;
        Destroy(gameObject);
    }

    void DropLoot(int loot)
    {
        if (loots.Length <= loot || !loots[loot])
            return;
        Instantiate(loots[loot], transform.position, Quaternion.identity);
    }

     void OnEnable()
    {
        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject obj in otherObjects)
        {  
                Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}
