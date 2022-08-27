using System.Collections.Generic;
using UnityEngine;

public class CharacterSumStatsComponent : MonoBehaviour, IMainStatsContainer
{
    private List<MainStats> _allMainStats = new List<MainStats>(8);

    private MainStats _currentMainStat;
    public MainStats CurrentMainStat => _currentMainStat;
    
    public void AddToSumMainStats(MainStats mainStat)
    {
        if (AllStatContain(mainStat))
        {
            _allMainStats.Add(mainStat);
            _currentMainStat += mainStat;
        }
    }

    public void RemoveFromSumMainStats(MainStats mainStat)
    {
        if (AllStatContain(mainStat))
        {
            _allMainStats.Remove(mainStat);
            _currentMainStat -= mainStat;
        }
    }

    private bool AllStatContain(MainStats mainStat)
    {
        return !_allMainStats.Contains(mainStat);
    }
}

public interface IMainStatsContainer
{
    void AddToSumMainStats(MainStats mainStats);
    void RemoveFromSumMainStats(MainStats mainStats);
}