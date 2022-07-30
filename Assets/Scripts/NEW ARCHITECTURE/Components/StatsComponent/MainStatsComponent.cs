using UnityEngine;

public class MainStatsComponent : MonoBehaviour, IActorsMainStats
{
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
    
    public Actor Actor { get; set; }
}