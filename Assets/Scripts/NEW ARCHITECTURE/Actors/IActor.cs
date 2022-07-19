
public interface IActor : ICanBePaused, ICanSetBehaviour
{
    
}

public interface ICanBePaused
{
    void SetPause(bool value);
}

public interface ICanSetBehaviour
{
    void AddBehaviour(IBehaviour behaviour);
}