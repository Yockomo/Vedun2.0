using System;
using UnityEngine;

[Serializable]
public struct MainStats
{
    [SerializeField] private int _health;
    public int Health
    {
        get => _health;
        private set => _health = value;
    }
    
    [SerializeField] private int _energy;
    public int Energy
    {
        get => _energy;
        private set => _energy = value;
    }

    [SerializeField] private int _strength;
    public int Strength
    {
        get => _strength;
        private set => _strength = value;
    }

    [SerializeField] private int _agility;
    public int Agility
    {
        get => _agility;
        private set => _agility = value;
    }

    [SerializeField] private int _defence;
    public int Defence
    {
        get => _defence;
        private set => _defence = value;
    }

    public MainStats(int health, int energy, int strength, int agility, int defence) : this()
    {
        Health = health;
        Energy = energy;
        Strength = strength;
        Agility = agility;
        Defence = defence;
    }

    public void ChangeHealthStat(int value) 
    {
        Health += value;
    }

    public void ChangeEnergyStat(int value)
    {
        Energy += value;
    }

    public void ChangeStrength(int value)
    {
        Strength += value;
    }

    public void ChangeAgilityStat(int value)
    {
        Agility += value;
    }

    public void ChangeDefenceStat(int value)
    {
        Defence += value;
    }
}