using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedievalAI : MonoBehaviour {
    public float speed = 2f;
    public bool facingright;
    private float prevX = 0;
    public GameObject target;
    private Vector3 pos;
    private Animator animator;
    private GameObject player;
    private bool attacking;
    private BoxCollider2D box;
    private float attackTimer = 0;
    private float attackCd = 0.8f; 
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        pos = player.transform.position;
        animator = GetComponent<Animator>();
        attacking = false;
    }

    void Update() {

        pos = player.transform.position;

        HandleMovement();
        HandleRotation();
        Attacks();

    }

    void Attacks() {
        if (Mathf.Abs(transform.position.x - pos.x) <= 1.2 && !attacking && attackTimer <= 0) {
            attacking = true;
            attackTimer = attackCd;
            animator.Play("Attack1");
        } 
        if (attacking) {
            if (attackTimer > 0)
                attackTimer -= Time.deltaTime;
            else
                attacking = false;
        }
    }

    void HandleMovement() {
        if (pos.x < transform.position.x && !attacking) {
            transform.position += -Vector3.right * speed * Time.deltaTime;
            animator.Play("Run");
        } else if (pos.x > transform.position.x && !attacking) {
            transform.position += Vector3.right * speed * Time.deltaTime;
            animator.Play("Run");
        }
    }

    void HandleRotation() {
        if (prevX > transform.position.x && !facingright && !attacking) {
            Xflip();
        } else if (prevX < transform.position.x && facingright && !attacking) {
            Xflip();
        }
        prevX = transform.position.x;
    }

    void Xflip() {
        facingright = !facingright;
        transform.Rotate(0f, 180f, 0f);
    }
}