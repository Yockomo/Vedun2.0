using SOScripts;
using UnityEngine;

    public class StubAtackBehaviourContainer : AtackBehaviourContainer
    {
        [SerializeField] private EnemyAtackConfig stubAtackConfig;

        private DefaultEnemyAtackBehaviour _enemyDefaultAtackBehaviour;

        public override AtackBehaviour<ICanAtack> GetValue => _enemyDefaultAtackBehaviour;
        
        protected override void Init()
        {
            if (TryGetComponent<ICanAtack>(out var atacker))
                _enemyDefaultAtackBehaviour = new DefaultEnemyAtackBehaviour(atacker, stubAtackConfig);
            else
                Debug.LogError("нет компонента ICanAtack на " + gameObject.name);
        }
    }

public abstract class AtackBehaviourContainer : BehaviourContainer<AtackBehaviour<ICanAtack>>
{
    
}