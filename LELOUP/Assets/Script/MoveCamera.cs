using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float Speed = 5;

    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * Speed / 100;
        
        transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y, transform.position.z + 0);
    }
}
