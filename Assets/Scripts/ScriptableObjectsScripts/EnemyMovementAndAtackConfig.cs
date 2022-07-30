using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyChaiseMoveConfig", order = 1)]
public class EnemyMovementAndAtackConfig : ScriptableObject
{
    [SerializeField] private float stoppingDistance = 1;
    
    [SerializeField] private float reactDistance;
    
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3;
    
    public float StoppingDistance => stoppingDistance;
    public float ReactDistance => reactDistance;
    public float MoveSpeed => moveSpeed;
}