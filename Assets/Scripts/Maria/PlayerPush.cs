using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public float pushPower = 10f;
    public StatesManager statesManager;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Solo el estado grande puede abrir la puerta
        if (statesManager.currentState != StatesManager.State.Big)
            return;

        // Solo afecta a objetos con la tag Door
        if (!hit.collider.CompareTag("Door"))
            return;

        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        body.AddForce(pushDir * pushPower, ForceMode.Impulse);
    }
}