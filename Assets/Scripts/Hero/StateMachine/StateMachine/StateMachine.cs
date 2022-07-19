
public class StateMachine
{
    private State _currentState;

    public StateMachine(State initializingState)
    {
        _currentState = initializingState;
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState.Update();
    }

    public void ChangeState(State newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}
