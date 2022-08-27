using System;
using UnityEngine;

[Serializable]
public struct MainStats
{
    [SerializeField] private int _health;
    public int Health
    {
        get => _health;
        set => _health = value >= 0 ? value : _health;
    }
    
    [SerializeField] private int _energy;
    public int Energy
    {
        get => _energy;
        set => _energy = value >= 0 ? value : _energy;
    }

    [SerializeField] private int _strength;
    public int Strength
    {
        get => _strength; 
        set => _strength = value >= 0 ? value : _strength;
    }

    [SerializeField] private int _agility;
    public int Agility
    {
        get => _agility; 
        set => _agility = value >= 0 ? value : _agility;
    }

    [SerializeField] private int _defence;
    public int Defence
    {
        get => _defence;
        set => _defence = value >= 0 ? value : _defence;
    }

    public MainStats(int health, int energy, int strength, int agility, int defence) : this()
    {
        Health = health;
        Energy = energy;
        Strength = strength;
        Agility = agility;
        Defence = defence;
    }

    public static MainStats operator +(MainStats firstStat, MainStats secondStat)
    {
        var health = firstStat.Health + secondStat.Health;
        var energy = firstStat.Energy + secondStat.Energy;
        var strength = firstStat.Strength + secondStat.Strength;
        var agility = firstStat.Agility + secondStat.Agility;
        var defence = firstStat.Defence + secondStat.Defence;

        return new MainStats(health,energy,strength,agility,defence);
    }    
    
    public static MainStats operator -(MainStats firstStat, MainStats secondStat)
    {
        var health = firstStat.Health - secondStat.Health;
        var energy = firstStat.Energy - secondStat.Energy;
        var strength = firstStat.Strength - secondStat.Strength;
        var agility = firstStat.Agility - secondStat.Agility;
        var defence = firstStat.Defence - secondStat.Defence;

        return new MainStats(health,energy,strength,agility,defence);
    }
}