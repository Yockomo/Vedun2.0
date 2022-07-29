using System;
using System.ComponentModel;
using UnityEngine;

public abstract class Health : MonoBehaviour, IHealth, IHealthChanger
{
    [SerializeField] protected int fullHealth = 100;
    
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
    
    public void AddValue(int count)
    {
        currentHealth += count;
        if (currentHealth > fullHealth) currentHealth = fullHealth;
        Changed?.Invoke(count, currentHealth);
    }

    public void DecValue(int count)
    {
        currentHealth -= count;
        Changed?.Invoke(count, currentHealth);
    }
}
