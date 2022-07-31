using UnityEngine;

public class MainStatsComponent : MonoBehaviour, IActorsMainStats
{
    public Actor Actor { get; set; }
    
    [SerializeField] private MainStats mainStats;
    public MainStats ActorsMainStats 
    {
        get
        {
            return mainStats;
        }
        
        set
        {
        } 
    }

    private Health _actorsHealthComponent;
    public Health ActorHealth => _actorsHealthComponent;
    
    private void Start()
    {
        if (TryGetComponent<Health>(out var healthComponent))
        {
            _actorsHealthComponent = healthComponent;
            _actorsHealthComponent.SetFullHealthValue(mainStats.Health);
        }
        else
            Debug.LogError("There is no HealthComponent on " + gameObject.name);

        if (TryGetComponent<IMainStatsContainer>(out var sumStatsContainer))
        {
            sumStatsContainer.IncludeMainStat(mainStats);
        }
    }
}