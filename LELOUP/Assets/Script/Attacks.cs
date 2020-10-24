using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attacks : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;
    public float fourAttackRange = 0.5f;
    public int fourAttackDamage = 20;
    public int bullet = 0;
    public Text bulletNumber;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ManageBullets();
        if (Input.GetKeyDown(KeyCode.R))
        {
            Attack();
        }
    }

    void Attack()
    {
        float attRange = 0;
        int attDmg = 0;

        if (gameObject.GetComponent<Movements>().gunMode)
        {
            animator.SetTrigger("PistolShoot");
        }
        else if (gameObject.GetComponent<Movements>().isStanding)
        {
            animator.SetTrigger("Attack3");
            attRange = attackRange;
            attDmg = attackDamage;
        }
        else
        {
            animator.SetTrigger("4Attack");
            attRange = fourAttackRange;
            attDmg = fourAttackDamage;
        }


        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(attDmg);
        }
    }

    void ManageBullets()
    {
        bulletNumber.text = "x" + bullet;
    }
}
