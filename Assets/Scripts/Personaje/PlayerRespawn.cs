using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform currentCheckpoint;
    private Rigidbody rb;

    [Header("Bridge")]
    [SerializeField] private GameObject puentePrefab;
    [SerializeField] private GameObject puenteActual;

    private Vector3 puenteStartPos;
    private Quaternion puenteStartRot;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        puenteStartPos = puenteActual.transform.position;
        puenteStartRot = puenteActual.transform.rotation;
    }

    public void Respawn()
    {
        if (puenteActual != null)
        {
            Destroy(puenteActual);
        }

        puenteActual = Instantiate(
            puentePrefab,
            puenteStartPos,
            puenteStartRot
        );

        transform.position = currentCheckpoint.position;
        transform.rotation = currentCheckpoint.rotation;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
