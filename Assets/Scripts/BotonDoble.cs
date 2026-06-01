using UnityEngine;

public class BotonDoble : MonoBehaviour
{
    [SerializeField] private BotonPuerta buttonA;
    [SerializeField] private BotonPuerta buttonB;
    [SerializeField] private GameObject puerta;

    private bool lastState;

    void Update()
    {
        bool active = buttonA.EstaActivo() && buttonB.EstaActivo();

        if (active != lastState)
        {
            puerta.SetActive(!active);
            lastState = active;
        }
    }
}
