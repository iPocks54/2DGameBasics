using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 150;
    public float lifeTime = 5f;

    public AudioSource gunShot;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource newFire = Instantiate(gunShot);
        Destroy(newFire, 1f);
        newFire.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0.0f)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Enemy"))
        {
            hit.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
