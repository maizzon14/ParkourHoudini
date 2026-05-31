using UnityEngine;

public class BotonE : MonoBehaviour
{
    [SerializeField] private GameObject puerta;

   

    private bool jugadorCerca = false;
    private bool activado = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (jugadorCerca && !activado && Input.GetKeyDown(KeyCode.E))
        {
            activado = true;

            Destroy(puerta);
 
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
