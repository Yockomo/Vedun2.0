using UnityEngine;

    [CreateAssetMenu(fileName = "EnemyStats", menuName = "ScriptableObjects/EnemyChaiseMoveConfig", order = 1)]
    public class EnemyChaiseMoveConfig : ScriptableObject
    {
        [SerializeField] private float stoppingDistance = 1;
        [SerializeField] private float reactDistance;

        public float StoppingDistance => stoppingDistance;
        public float ReactDistance => reactDistance;
    }