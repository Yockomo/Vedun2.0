using System;

public interface IHealth
{
    public int Current {get;}
    public int Full {get;}
    public event Action<int, int> Changed;
}
