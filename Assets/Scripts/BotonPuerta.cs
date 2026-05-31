using UnityEngine;

public class BotonPuerta : MonoBehaviour
{
    [SerializeField] private GameObject puerta;

    private bool activado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activado) return;

        if (other.CompareTag("Box"))
        {
            activado = true;
            Destroy(puerta);

            
        }
        
    
    }
}

