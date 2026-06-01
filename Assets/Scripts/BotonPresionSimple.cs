using UnityEngine;

public class BotonPresionSimple : MonoBehaviour
{
    [SerializeField] private GameObject puerta;

    private int cajasEncima = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            cajasEncima++;
            UpdatePuerta();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            cajasEncima = Mathf.Max(0, cajasEncima - 1);
            UpdatePuerta();
        }
    }

    void UpdatePuerta()
    {
        bool activarPuerta = cajasEncima == 0;

        puerta.SetActive(activarPuerta);
    }
}
