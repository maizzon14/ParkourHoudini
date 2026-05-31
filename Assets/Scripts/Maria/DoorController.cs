using UnityEngine;

public class DoorController : MonoBehaviour
{
    public StatesManager statesManager;
    private HingeJoint hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    void Update()
    {
        if (statesManager.currentState == StatesManager.State.Big)
        {
            hinge.useLimits = true; // puede abrirse
        }
        else
        {
            Rigidbody rb = GetComponent<Rigidbody>();

            rb.angularVelocity = Vector3.zero;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}