using UnityEngine;
using UnityEngine.InputSystem;

public class BallMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody rb;
    private Vector2 inputVector;
    private Vector3 direction;
    private InputSystemActions inputSystem;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputSystem = new InputSystemActions();
        inputSystem.Player.Enable();
        inputSystem.Player.Move.performed += Move;
    }

    private void FixedUpdate()
    {
        rb.AddForce(direction * moveSpeed, ForceMode.Impulse);
        direction = Vector3.zero;
    }

    private void Move(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
        direction = new Vector3(inputVector.x, 0f, inputVector.y).normalized;
    }
}
