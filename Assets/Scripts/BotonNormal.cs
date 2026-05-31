using UnityEngine;
using UnityEngine.InputSystem;

public class BotonNormal : MonoBehaviour
{
    [SerializeField] private GameObject puerta;

    private bool jugadorCerca = false;
    private bool activado = false;

    PlayerInput input;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
    }
    void Update()
    {
        if (jugadorCerca && !activado && input.actions["Interact"].triggered)
        {
            activado = true;

            puerta.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
        }

    }
}
