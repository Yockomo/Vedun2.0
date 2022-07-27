using System;

public interface ICanSetState<T> where T : Enum
{ 
    public void SetState(T state);
}