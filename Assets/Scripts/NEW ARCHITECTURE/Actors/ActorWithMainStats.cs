using UnityEngine;

public class ActorWithMainStats : Actor, IHaveMainStats
{
    protected IActorsMainStats _actorsMainStats;
    
    public IActorsMainStats MainStatsContainer 
    {
        get => _actorsMainStats;
        set        
        {
            if (_actorsMainStats == null)
            {
                _actorsMainStats = value;
            }
        }
    }

    protected override void Start()
    {
        GetMainStats();
        base.Start();
    }

    private void GetMainStats()
    {
        if (TryGetComponent<IActorsMainStats>(out var actorsMainStats))
        {
            _actorsMainStats = actorsMainStats;
        }
        else
            Debug.LogError("There is no MainStatsComponent on" +gameObject.name);
    }

    protected override void Init()
    {
    }
}