using System.Collections.Generic;
using UnityEngine;

public class CharacterSumStatsComponent : MonoBehaviour, IMainStatsContainer
{
    private List<MainStats> _allMainStats = new List<MainStats>(5);
    
    public void IncludeMainStat(MainStats mainStats)
    {
        _allMainStats.Add(mainStats);
    }

    public int GetCurrentMaxHealthSum()
    {
        var sum = 0;
        foreach (var stat in _allMainStats)
        {
            sum += stat.Health;
        }

        return sum;
    }

    public int GetCurrentMaxEnergySum()
    {
        var sum = 0;
        foreach (var stat in _allMainStats)
        {
            sum += stat.Energy;
        }

        return sum;
    }

    public int GetCurrentStrengthSum()
    {
        var sum = 0;
        foreach (var stat in _allMainStats)
        {
            sum += stat.Strength;
        }

        return sum;
    }

    public int GetCurrentAgilitySum()
    {
        var sum = 0;
        foreach (var stat in _allMainStats)
        {
            sum += stat.Agility;
        }

        return sum;
    }

    public int GetCurrentDefenceSum()
    {
        var sum = 0;
        foreach (var stat in _allMainStats)
        {
            sum += stat.Defence;
        }

        return sum;
    }

    public MainStats GetCurrentMainStats()
    {
        return new MainStats(GetCurrentMaxEnergySum(), GetCurrentMaxEnergySum(), GetCurrentStrengthSum(),
            GetCurrentAgilitySum(), GetCurrentDefenceSum());
    }
}

public interface IMainStatsContainer
{
    void IncludeMainStat(MainStats mainStats);
}