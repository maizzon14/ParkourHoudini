using UnityEngine;

public class Movible : MonoBehaviour
{
    public float posicionSmall = 2f;
    public float posicionMedium = 0f;
    public float posicionBig = -2f;

    public float velocidad = 2f;

    Vector3 posicionInicial;
    Vector3 posicionObjetivo;

    void Start()
    {
        posicionInicial = transform.position;
        posicionObjetivo = posicionInicial;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,posicionObjetivo,velocidad * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        StatesManager player = other.GetComponent<StatesManager>();

        if (player != null)
        {
            other.transform.SetParent(transform);

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
    }

    private void OnTriggerExit(Collider other)
    {
        StatesManager player = other.GetComponent<StatesManager>();

        if (player != null)
        {
            other.transform.SetParent(null);
            posicionObjetivo = posicionInicial;
        }
    }
}
