using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 20f;

    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
       offset=transform.position-target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {



        Vector3 camPos = target.position+offset;
        if (target.position.y < 0)
        {
            camPos.y = 0;
        }

        transform.position = Vector3.Lerp(transform.position, camPos, smoothing * Time.deltaTime);



    }
}
