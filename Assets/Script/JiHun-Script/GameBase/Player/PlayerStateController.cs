using UnityEngine;

public abstract class State
{
    public State(string stateName)
    {
        this.stateName = stateName;
    }
    public readonly string stateName;
    public virtual void EnterState() { }
    public virtual void StayState() { }
    public virtual void ExitState() { }
}

public class PlayerStateController : MonoBehaviour
{
    private void Update()
    {
        currentState.StayState();
    }
    public void SetCurrentState(State state)
    {
        if (currentState != null)
            currentState.ExitState();

        currentState = state;

        currentState.EnterState();
    }
    public bool IsCurrentState(State state)
    {
        return currentState == state;
    }
    private State currentState;
}

public abstract class StateTransition
{
    public StateTransition(PlayerStateController playerStateController, State state1, State state2)
    {
        this.playerStateController = playerStateController;
        this.state1 = state1;
        this.state2 = state2;
    }
    protected void changeState()
    {
        if (playerStateController.IsCurrentState(state1) == false)
            return;

        playerStateController.SetCurrentState(state2);
    }

    private PlayerStateController playerStateController = null;
    private State state1 = null;
    private State state2 = null;
}