using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpMovment : MonoBehaviour
{
    public float speedMovment;
    public Vector3 moveDirection;
    public float moveDistance;
    private Vector3 startPosition;

     void Start()
    {
        startPosition = gameObject.transform.position;
    }
     void FixedUpdate()
    {
        transform.position = startPosition + moveDirection * (moveDistance * Mathf.Sin(Time.time * speedMovment));
    }
}
