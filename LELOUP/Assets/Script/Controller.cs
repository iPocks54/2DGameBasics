using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speed = 10f;
    bool facingright = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var movement = Input.GetAxis("Horizontal");

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * speed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 5f;
            rb.velocity = Vector2.up * jumpVelocity;
        }

        if (movement < 0 && !facingright)
        {
            Xflip();
        }
        else if (movement > 0 && facingright)
        {
            Xflip();
        }
    }

    void Xflip()
    {
        facingright = !facingright;
        transform.Rotate(0f, 180f, 0f);
    }
}
