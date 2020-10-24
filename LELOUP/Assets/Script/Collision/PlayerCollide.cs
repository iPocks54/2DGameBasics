using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollide : MonoBehaviour
{
    private int colliderCheck;
    private BoxCollider2D box;
    // Start is called before the first frame update
    void Start()
    {
        colliderCheck = 0;
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Attack") && colliderCheck == 0) {
            Debug.Log("Salut ça hit");
            colliderCheck += 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        colliderCheck = 0;
    }
}
