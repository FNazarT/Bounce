using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public float bounceVelocity = 6f, fallMultiplier = 3f;
    private Rigidbody rb;
    private Vector3 startingPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingPos = transform.position;
    }

    private void FixedUpdate()
    {
        if (transform.position.y <= -5f) { transform.position = startingPos; }

        //If the ball is moving down, gravity is applied so it falls faster
        if (rb.velocity.y < 0) { rb.velocity += Physics.gravity * fallMultiplier * Time.deltaTime; }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.up * bounceVelocity;
        startingPos = transform.position;
    }
}
