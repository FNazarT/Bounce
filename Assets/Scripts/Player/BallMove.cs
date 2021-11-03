using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    [SerializeField] private float h, v, longMove = 14f, shortMove = 7;
    private float moveSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        moveSpeed = Input.GetKey(KeyCode.Space) ? longMove : shortMove;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(h * moveSpeed, rb.velocity.y, v * moveSpeed);
    }
}
