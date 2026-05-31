using UnityEngine;
using UnityEngine.InputSystem;

public class PickUpSystem : MonoBehaviour
{
    public float grabDistance = 3f;
    public Transform holdPoint;
    public StatesManager statesManager;

    private Rigidbody heldObject;
    private PlayerInput input;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        // Si llevas una caja y cambias a Medium o Small, la sueltas
        if (heldObject != null && statesManager.currentState != StatesManager.State.Big)
        {
            DropObject();
        }

        // Detectar la acción Interact
        if (input.actions["Interact"].triggered)
        {
            Interact();
        }
    }

    public void Interact()
    {
        if (statesManager.currentState != StatesManager.State.Big)
        {
            Debug.Log("Necesitas ser grande para coger cajas");
            return;
        }

        if (heldObject == null)
        {
            GrabObject();
        }
        else
        {
            DropObject();
        }
    }

    void GrabObject()
    {
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, grabDistance);

        foreach (Collider col in nearbyObjects)
        {
            if (col.CompareTag("Box"))
            {
                heldObject = col.GetComponent<Rigidbody>();

                if (heldObject != null)
                {
                    heldObject.useGravity = false;
                    heldObject.linearVelocity = Vector3.zero;
                }

                break;
            }
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            heldObject.useGravity = true;
            heldObject = null;
        }
    }

    void FixedUpdate()
    {
        if (heldObject != null)
        {
            heldObject.MovePosition(holdPoint.position);
        }
    }
}