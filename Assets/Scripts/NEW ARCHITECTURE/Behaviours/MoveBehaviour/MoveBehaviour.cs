
public abstract class MoveBehaviour<T> : BaseBehaviour, IMoveBehaviour where T : IMovable
{
    protected T _movable;
    protected MoveState _currentState;

    protected MoveBehaviour(T movable)
    {
        _movable = movable;
    }
}

public enum MoveState { DEFAULT, PAUSE, UNPAUSE, ATACK }
