using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int deathScore = 0;
    int currentHealth;
    public GameObject[] loots;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (Random.Range(0, 3) == 2)
            DropLoot(0);
        if (Random.Range(0, 5) == 1)
            DropLoot(1);
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
