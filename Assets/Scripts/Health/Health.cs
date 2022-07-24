using System;
using UnityEngine;

public class Health : MonoBehaviour, IHealth, IHealthChanger
{
    public int Current => currentHealth;
    public int Full => fullHealth;

    [SerializeField] private int fullHealth = 100;
    
    private int currentHealth;

    public event Action<int, int> Changed;

    private void Start()
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
