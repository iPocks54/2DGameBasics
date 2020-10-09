using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public float speed = 3;
    private Transform targets;
    bool facingright = true;
    private float prevX = 0;
    void Start()
    {
        targets = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targets.position, speed * Time.deltaTime);
        
        
        if ( prevX > transform.position.x && !facingright)
        {
            Xflip();
        }
        else if (prevX < transform.position.x && facingright)
        {
            Xflip();
        }

        prevX = transform.position.x;
    }

    void Xflip()
    {
        facingright = !facingright;
        transform.Rotate(0f, 180f, 0f);
    }
}
