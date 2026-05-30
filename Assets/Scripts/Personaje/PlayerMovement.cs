using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    PlayerInput input;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;

    Vector2 moveInput;

    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float floorDistance = 1.2f;

    [SerializeField] private Transform cameraTransform;
    [SerializeField] private bool shouldFaceMoveDirection = false;

    [SerializeField] private float acceleration = 10f;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        moveInput = input.actions["Move"].ReadValue<Vector2>();

        CheckGround();
    }

    private void FixedUpdate()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;
        
        Vector3 currentVelocity = rb.linearVelocity;

        Vector3 targetVelocity = moveDirection * speed;

        Vector3 velocityChange = targetVelocity - new Vector3(currentVelocity.x, 0, currentVelocity.z);

        velocityChange = Vector3.ClampMagnitude(velocityChange, acceleration * Time.fixedDeltaTime);

        currentVelocity.x += velocityChange.x;
        currentVelocity.z += velocityChange.z;

        rb.linearVelocity = currentVelocity;

        if (shouldFaceMoveDirection && moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, toRotation, Time.fixedDeltaTime * 10f));
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void CheckGround() 
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, floorDistance);
    }
}
