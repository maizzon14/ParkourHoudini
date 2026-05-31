using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    public float grabDistance = 3f;
    public Transform holdPoint;

    private Rigidbody heldObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldObject == null)
            {
                GrabObject();
            }
            else
            {
                DropObject();
            }
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