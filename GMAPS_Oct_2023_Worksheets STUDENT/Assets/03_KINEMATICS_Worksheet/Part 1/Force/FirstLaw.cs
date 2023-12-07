using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLaw : MonoBehaviour
{
    public Vector3 force;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get Rigidbody component


        rb.AddForce(force); // Add force to Rigidbody

    }

    void FixedUpdate()
    {
        Debug.Log(transform.position);
    }
}