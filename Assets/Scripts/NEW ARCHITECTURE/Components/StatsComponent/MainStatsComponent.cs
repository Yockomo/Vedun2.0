using UnityEngine;

public class MainStatsComponent : MonoBehaviour, IActorsMainStats
{
    [SerializeField] private MainStats _mainStats;
    public MainStats ActorsMainStats 
    {
        get => _mainStats;
        set{}
    }

    private Health _actorsHealthComponent;
    public Health ActorHealth => _actorsHealthComponent;
    
    private void Start()
    {
        if (TryGetComponent<Health>(out var healthComponent))
        {
            _actorsHealthComponent = healthComponent;
            _actorsHealthComponent.SetFullHealthValue(_mainStats.Health);
        }
        else
            Debug.LogError("There is no HealthComponent on " + gameObject.name);

        if (TryGetComponent<IMainStatsContainer>(out var sumStatsContainer))
        {
            sumStatsContainer.AddToSumMainStats(_mainStats);
        }
    }
}