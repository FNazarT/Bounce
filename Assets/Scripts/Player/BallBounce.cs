using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public float bounceVelocity = 6f, fallMultiplier = 3f;
    private bool canBounce;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canBounce = false;
    }

    private void FixedUpdate()
    {
        if (canBounce)
        {
            rb.velocity = Vector3.up * bounceVelocity;
            canBounce = false;
        }

        if(rb.velocity.y < 0)       //If the ball is moving down, gravity is applied so it falls faster
        {
            rb.velocity += Physics.gravity * fallMultiplier * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canBounce = true;
    }
}
