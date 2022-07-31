using System;

public interface IHealthChanger
{
    public event Action<int, int> Changed;
    public void AddValue(int count);
    public void DecValue(int count);
}
