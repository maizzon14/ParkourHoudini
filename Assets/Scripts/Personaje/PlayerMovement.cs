using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    PlayerInput input;

    private float speed;
    private float jumpForce;

    
    private Vector3 currentHorizontalVelocity;

    public float speedMovement
    {
        get { return speed; }
        set { speed = value; }
    }
    public float JumpForce
    {
        get { return jumpForce; }
        set { jumpForce = value; }
    }

    private enum MoveMode
    {
        Normal,
        Ice
    }

    private MoveMode moveMode = MoveMode.Normal;

    Vector2 moveInput;

    [SerializeField] private bool isGrounded = false;
    [SerializeField] private bool isOnIce = false;
    [SerializeField] private float floorDistance = 1.2f;
    [SerializeField] private float iceDistance = 3f;

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
        Vector3 velocity = rb.linearVelocity;

        Vector3 moveDirection = cameraTransform.forward * moveInput.y + cameraTransform.right * moveInput.x;
        moveDirection.y = 0;
        moveDirection.Normalize();

        Vector3 horizontal = new Vector3(velocity.x, 0, velocity.z);

        if (moveMode == MoveMode.Ice)
        {
            float accel = acceleration * Time.fixedDeltaTime * 0.2f;
            float friction = 0.995f;

            horizontal += moveDirection * speed * accel;
            horizontal *= friction;
        }
        else
        {
            Vector3 currentVelocity = rb.linearVelocity;

            Vector3 targetVelocity = moveDirection * speed;

            Vector3 velocityChange = targetVelocity - new Vector3(currentVelocity.x, 0, currentVelocity.z);

            velocityChange = Vector3.ClampMagnitude(velocityChange, acceleration * Time.fixedDeltaTime);

            currentVelocity.x += velocityChange.x;
            currentVelocity.z += velocityChange.z;

            horizontal = new Vector3(currentVelocity.x, 0, currentVelocity.z);
        }

        float maxSpeed = speed * (moveMode == MoveMode.Ice ? 2f : 1f);
        horizontal = Vector3.ClampMagnitude(horizontal, maxSpeed);

        rb.linearVelocity = new Vector3(horizontal.x, velocity.y, horizontal.z);

        if (shouldFaceMoveDirection && moveDirection.sqrMagnitude > 0.01f)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, toRotation, Time.fixedDeltaTime * 10f));
        }
    }

    public void SetStats(float speed, float jumpForce)
    {
        this.speed = speed;
        this.jumpForce = jumpForce;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            Vector3 velocity = rb.linearVelocity;

            rb.linearVelocity = new Vector3(velocity.x, 0, velocity.z);

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void CheckGround() 
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, floorDistance);
        isOnIce = Physics.Raycast(transform.position, Vector3.down, iceDistance, LayerMask.GetMask("Ice"));
    }

    private void OnCollisionStay(Collision collision)
    {
        if(isOnIce)
        {
            moveMode = MoveMode.Ice;
        }
        else 
        {
            moveMode = MoveMode.Normal;
        }
    }
}
