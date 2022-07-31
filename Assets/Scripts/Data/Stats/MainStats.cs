using System;
using UnityEngine;

[Serializable]
public struct MainStats
{
    [SerializeField] private float _health;
    public float Health
    {
        get => _health;
        private set => _health = value;
    }
    
    [SerializeField] private float _energy;
    public float Energy
    {
        get => _energy;
        private set => _energy = value;
    }

    [SerializeField] private float _strength;
    public float Strength
    {
        get => _strength;
        private set => _strength = value;
    }

    [SerializeField] private float _agility;
    public float Agility
    {
        get => _agility;
        private set => _agility = value;
    }

    [SerializeField] private float _defence;
    public float Defence
    {
        get => _defence;
        private set => _defence = value;
    }

    public MainStats(float health, float energy, float strength, float agility, float defence) : this()
    {
        Health = health;
        Energy = energy;
        Strength = strength;
        Agility = agility;
        Defence = defence;
    }

    public void ChangeHealthStat(float value) 
    {
        Health += value;
    }

    public void ChangeEnergyStat(float value)
    {
        Energy += value;
    }

    public void ChangeStrength(float value)
    {
        Strength += value;
    }

    public void ChangeAgilityStat(float value)
    {
        Agility += value;
    }

    public void ChangeDefenceStat(float value)
    {
        Defence += value;
    }
}