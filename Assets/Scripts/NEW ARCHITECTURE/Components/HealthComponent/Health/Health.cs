using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IHealth, IHealthChanger
{
    protected int fullHealth;
    protected int currentHealth;

    public int CurrentHealth => currentHealth;
    public int FullHealth => fullHealth;
    public event Action<int, int> Changed;

    private void Start()
    {
        OnStartFunction();
    }

    protected virtual void OnStartFunction()
    {
        currentHealth = fullHealth;
    }

    public void SetFullHealthValue(int value)
    {
        fullHealth = value;
        Changed?.Invoke(fullHealth,currentHealth);
    }

    public void ChangeFullHealth(int value)
    {
        fullHealth += value;
        Changed?.Invoke(fullHealth, currentHealth);
    }
    
    public void AddValue(int count)
    {
        currentHealth += count;
        if (currentHealth > fullHealth) currentHealth = fullHealth;
        Changed?.Invoke(fullHealth, currentHealth);
    }

    public void DecValue(int count)
    {
        currentHealth -= count;
        Changed?.Invoke(fullHealth, currentHealth);
    }
}
