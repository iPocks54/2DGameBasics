using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class Movements : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public float fourMoveSpeed;
    public Animator anim;

    public bool isGrounded;
    public bool isStanding;
    public bool lookright = true;
    public LayerMask groundLayers;

    void Start()
    {

        anim = GetComponent<Animator>();
        anim.SetLayerWeight(0, 1);

        anim.SetTrigger("Idle");
        //cam = GetComponent<Camera>();
    }

    void Update()
    {

        if (isStanding)
        {
            isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.405f - 0.1302271f, transform.position.y - 0.6625f - 0.00651145f), new Vector2(transform.position.x + 0.405f - 0.1302271f, transform.position.y + 0.6625f - 0.00651145f), groundLayers);

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
                anim.Play("Jump");
            }
            else if (Input.GetKey(KeyCode.RightArrow) && isGrounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
                transform.localScale = new Vector2(1, 1);
                anim.Play("Run");
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && isGrounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
                transform.localScale = new Vector2(-1, 1);
                anim.Play("Run");
            }
        }
        else
        {
            isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - (0.6625f - 0.1194419f), transform.position.y - (0.405f + 0.2322474f)), new Vector2(transform.position.x + 0.6625f + 0.1194419f, transform.position.y + 0.405f - 0.2322474f), groundLayers);
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
                anim.Play("4Jump");
            }
            else if (Input.GetKey(KeyCode.RightArrow) && isGrounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(fourMoveSpeed, 0);
                transform.localScale = new Vector2(1, 1);
                anim.Play("4Run");
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && isGrounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-fourMoveSpeed, 0);
                transform.localScale = new Vector2(-1, 1);
                anim.Play("4Run");
            }

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            isStanding = !isStanding;
            if (!isStanding)
            {
                GetComponent<BoxCollider2D>().offset = new Vector2(0.1194419f, -0.2322474f);
                GetComponent<BoxCollider2D>().size = new Vector2(1.325f, 0.81f);
                anim.Play("4Idle");
            }
            else
            {
                GetComponent<BoxCollider2D>().offset = new Vector2(-0.255556f, -0.04173887f);
                GetComponent<BoxCollider2D>().size = new Vector2(0.5593423f, 1.209406f);
                anim.SetTrigger("Idle");
            }
        }

        /*if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isStanding)
            {
                anim.SetTrigger("4Attack");
            }
            else
            {
                anim.SetTrigger("Attack3");
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!isStanding)
            {
                anim.SetTrigger("4Attack");
            }
            else
            {
                anim.SetTrigger("Punch");
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.T))
            print("TTTTTTETETETETTZTETETETETETETTE");
        if (collision.gameObject.name.Equals("enemie(Clone)"))
            print("COLOLOLCOLCOLC");
        if (collision.gameObject.name.Equals("enemie(Clone)") && (Input.GetKeyDown(KeyCode.R)))
        {
            print("YOYOYOYOYO");
            Destroy(collision.gameObject);
        }
    }*/
    }
}
