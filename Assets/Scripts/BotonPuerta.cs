using UnityEngine;

public class BotonPuerta : MonoBehaviour
{
    private bool hayCaja = false;

    public bool EstaActivo()
    {
        return hayCaja;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            hayCaja = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            hayCaja = false;
        }
    }
}


