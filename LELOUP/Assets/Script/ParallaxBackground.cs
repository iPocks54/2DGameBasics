using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float speed;
    private float x;
    public float PontoDeDestino;
    public float PontoOriginal;
    void Start()
    {
        PontoOriginal = transform.position.x;
    }

    void LateUpdate()
    {
        float xAxisValue = Input.GetAxis("Horizontal");
        float zAxisValue = Input.GetAxis("Vertical");
        if (Camera.current != null)
        {
            Camera.current.transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue));
        }

        xAxisValue = transform.position.x;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);



        if (xAxisValue <= PontoDeDestino)
        {

            Debug.Log("hhhh");
            xAxisValue = PontoOriginal;
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }


    }
}

