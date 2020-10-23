using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public float speed = 1f;
    bool facingright = true;
    private float prevX = 0;
    public GameObject target;
    private Vector3 pos;
    void Start()
    {
        pos = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    void Update()
    {
        pos = GameObject.FindGameObjectWithTag("Player").transform.position;

        if (pos.x < transform.position.x)
        {
            transform.position += -Vector3.right * speed * Time.deltaTime;
        }
        else if (pos.x > transform.position.x)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

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
