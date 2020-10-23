using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : MonoBehaviour
{
    public float speed = 1;
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
}
