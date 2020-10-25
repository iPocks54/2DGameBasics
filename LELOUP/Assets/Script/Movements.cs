using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using UnityEngine.SceneManagement;

public class Movements : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public float fourMoveSpeed;
    public Animator anim;

    public bool isGrounded;
    public bool isStanding;
    public bool gunMode = false;
    public bool gun = false;
    public bool lookright = true;
    public LayerMask groundLayers;

    void Start()
    {

        anim = GetComponent<Animator>();
        anim.SetLayerWeight(0, 1);

        anim.SetTrigger("Idle");
    }

    void Update()
    {

        if (isStanding)
        {
            if (gunMode)
                moveStanding("Pistol");
            else
                moveStanding("");
            activateGunMode();
        }
        else
        {
            moveFour();
        }
        if (!gunMode)
            standToFour();
    }

    void standToFour()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isStanding = !isStanding;
            if (!isStanding)
                anim.Play("4Idle");
            else
                anim.SetTrigger("Idle");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(2);
        }
    }

    void activateGunMode()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && gun)
        {
            gunMode = !gunMode;
            if (gunMode)
                anim.Play("PistolIdle");
            else
                anim.Play("Idle");
        }
    }

    /*void moveStanding(string mode)
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.405f - 0.1302271f, transform.position.y - 0.6625f - 0.00651145f), new Vector2(transform.position.x + 0.405f - 0.1302271f, transform.position.y + 0.6625f - 0.00651145f), groundLayers);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            anim.Play(mode + "Jump");
        }
        else if (Input.GetKey(KeyCode.RightArrow) && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
            anim.Play(mode +"Run");
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);
            anim.Play(mode + "Run");
        }
    }*/

    void moveStanding(string mode)
    {
        float inputX = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveSpeed * inputX, 0, 0);
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.405f - 0.1302271f, transform.position.y - 0.6625f - 0.00651145f), new Vector2(transform.position.x + 0.405f - 0.1302271f, transform.position.y + 0.6625f - 0.00651145f), groundLayers);
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            anim.Play(mode + "Jump");
        }
        else if (Input.GetKey(KeyCode.RightArrow) && isGrounded)
        {
            transform.localScale = new Vector2(1, 1);
            anim.Play(mode + "Run");
                /*if (Input.GetKeyDown(KeyCode.Space))
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
                    anim.Play(mode + "Jump");
                }*/
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && isGrounded)
        {
            transform.localScale = new Vector2(-1, 1);
            anim.Play(mode + "Run");
        }
            movement *= Time.deltaTime;
            transform.Translate(movement);
    }

    void moveFour()
    {
        float inputX = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveSpeed * inputX, 0, 0);
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - (0.605f - 0.07139975f), transform.position.y - (0.284f + 0.3625833f)), new Vector2(transform.position.x + 0.6625f + 0.1194419f, transform.position.y + 0.405f - 0.2322474f), groundLayers);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            anim.Play("4Jump");
        }
        else if (Input.GetKey(KeyCode.RightArrow) && isGrounded)
        {
            transform.localScale = new Vector2(1, 1);
            anim.Play("4Run");
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && isGrounded)
        {
            transform.localScale = new Vector2(-1, 1);
            anim.Play("4Run");
        }
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }

    void moveGun()
    {

    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Gun"))
        {
            gun = true;
            Destroy(hit.gameObject);
        }
        if (hit.CompareTag("Bullet"))
        {
            GetComponent<Attacks>().bullet += 1;
            Destroy(hit.gameObject);
        }
    }
}
