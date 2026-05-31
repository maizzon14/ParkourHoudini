using UnityEngine;

public class Physic : MonoBehaviour
{
    public float normalSpeed = 5f;

    public float iceSpeed = 8f;         // Hielo
    public float stickySpeed = 2f;      // Pegajoso
    public float trampolineForce = 15f; // Cama elastica 

    private float currentSpeed;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = normalSpeed;
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ice"))
        {
            currentSpeed = iceSpeed;
        }
        else if (collision.gameObject.CompareTag("Tierra"))
        {
            currentSpeed = normalSpeed;
        }
        else if (collision.gameObject.CompareTag("Pegajoso"))
        {
            currentSpeed = stickySpeed;
        }
        else if (collision.gameObject.CompareTag("Cama elastica"))
        {
            currentSpeed = normalSpeed;
        }
        else
        {
            currentSpeed = normalSpeed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cama elastica"))
        {
            rb.AddForce(Vector3.up * trampolineForce, ForceMode.Impulse);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        currentSpeed = normalSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * currentSpeed * Time.deltaTime);
    }
    
  

}
