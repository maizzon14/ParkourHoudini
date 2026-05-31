using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerRespawn>().currentCheckpoint = respawnPoint;
            Debug.Log("Checkpoint activado: " + gameObject.name);
        }
    }
}
