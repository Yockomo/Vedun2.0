
public abstract class MoveBehaviour<T> : BaseBehaviour, IBehaviour where T : IMovable
{
    protected T movable;
    protected MoveState currentState;

    protected MoveBehaviour(T movable)
    {
        this.movable = movable;
    }
}

public enum MoveState { DEFAULT, PAUSE, UNPAUSE, ATACK }
