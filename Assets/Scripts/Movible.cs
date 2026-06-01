using UnityEngine;

public class Movible : MonoBehaviour
{
    public float posicionSmall = 2f;
    public float posicionMedium = 0f;
    public float posicionBig = -2f;
    public float velocidad = 2f;

    Vector3 posicionInicial;
    Vector3 posicionObjetivo;
    Vector3 lastPosition;

    void Start()
    {
        posicionInicial = transform.position;
        posicionObjetivo = posicionInicial;
        lastPosition = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,posicionObjetivo,velocidad * Time.deltaTime);
    }

    void FixedUpdate()
    {
        lastPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        StatesManager player = other.GetComponent<StatesManager>();

        if (player == null) return;

        switch (player.currentState)
        {
            case StatesManager.State.Small:
                posicionObjetivo = posicionInicial + Vector3.up * posicionSmall;
                break;

            case StatesManager.State.Medium:
                posicionObjetivo = posicionInicial + Vector3.up * posicionMedium;
                break;

            case StatesManager.State.Big:
                posicionObjetivo = posicionInicial + Vector3.up * posicionBig;
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb == null) return;

        Vector3 delta = transform.position - lastPosition;

        rb.MovePosition(rb.position + delta);
    }

    private void OnTriggerExit(Collider other)
    {
        StatesManager player = other.GetComponent<StatesManager>();
        if (player == null) return;

        posicionObjetivo = posicionInicial;
    }
}
