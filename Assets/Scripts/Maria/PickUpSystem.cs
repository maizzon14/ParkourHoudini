using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    public float grabDistance = 3f;
    public Transform holdPoint;
    public StatesManager statesManager;

    private Rigidbody heldObject;

    void Update()
    {
       
        if (heldObject != null && statesManager.currentState != StatesManager.State.Big)
        {
            DropObject();
        }

        if (Input.GetKeyDown(KeyCode.E))
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

                    // Si te da error aquí, cambia por velocity
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