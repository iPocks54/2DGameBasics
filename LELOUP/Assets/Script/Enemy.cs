using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int deathScore = 0;
    int currentHealth;

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
        Debug.Log("Enemy died!");
        GameObject[] score = GameObject.FindGameObjectsWithTag("Score");
        if (score.Length != 0)
            score[0].GetComponent<Score>().score += deathScore;
        Destroy(this.gameObject);
    }
}
