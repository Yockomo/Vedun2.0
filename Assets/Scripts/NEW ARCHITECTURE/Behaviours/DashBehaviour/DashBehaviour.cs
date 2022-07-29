
public abstract class DashBehaviour<T> : BaseBehaviour, IDashBehaviour, ICanSetState<DashState> where T : IDashable
{
    protected T _dashable;
    protected DashState _currentState;
    
    protected DashBehaviour(T dashable)
    {
        _dashable = dashable;
    }

    public void SetState(DashState state)
    {
        _currentState = state;
    }
}

public enum DashState { DEFAULT, DASH, PAUSE, UNPAUSE }

public interface IDashBehaviour : IBehaviour
{
}