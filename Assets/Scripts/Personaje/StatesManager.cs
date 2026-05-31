using UnityEngine;
using UnityEngine.InputSystem;

public class StatesManager : MonoBehaviour
{
    public enum State
    {
        Small,
        Medium,
        Big
    }

    public State currentState;

    public StatesData statesDataSmall;
    public StatesData statesDataMedium;
    public StatesData statesDataBig;

    public PlayerMovement playerScript;
    Rigidbody rb;

    [SerializeField] private State startingState = State.Medium;

    private void Start()
    {
        rb = playerScript.GetComponent<Rigidbody>();

        currentState = startingState;

        ApplyState();
    }

    public void SetState(State newState)
    {
        if(currentState == newState) return;

        currentState = newState;
        ApplyState();
    }

    void ApplyState()
    {
        StatesData data = GetData(currentState);

        rb.mass = data.mass;
        rb.transform.localScale = data.scale;
        playerScript.SetStats(data.speed, data.jumpForce);
    }

    StatesData GetData(State state)
    {
        switch(state)
        {
            case State.Small:
                return statesDataSmall;
            case State.Medium:
                return statesDataMedium;
            case State.Big:
                return statesDataBig;
            default:
                return statesDataMedium;
        }
    }

    public void OnChangeState(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        switch(context.control.name)
        {
            case "1":
                SetState(State.Small);
                break;
            case "2":
                SetState(State.Medium);
                break;
            case "3":
                SetState(State.Big);
                break;
        }
    }
}