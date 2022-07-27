using UnityEngine;
using Zenject;

public class StubAtackBehaviourContainer : AtackBehaviourContainer
    {
        [SerializeField] private EnemyMovementAndAtackConfig stubAtackConfig;
        [SerializeField] private bool animateAtack;
        
        private DefaultEnemyAtackBehaviour _enemyDefaultAtackBehaviour;
        private Transform _playersTransform;
        
        public override AtackBehaviour<ICanAtack> GetValue => _enemyDefaultAtackBehaviour;

        [Inject]
        private void Construct(Player player)
        {
            _playersTransform = player.GetComponent<Transform>();
        }
        
        protected override void Init()
        {   
            GetICanAtackComponent();
        }

        private void GetICanAtackComponent()
        {
            if (TryGetComponent<ICanAtack>(out var atacker))
            {
                if(animateAtack)
                    _enemyDefaultAtackBehaviour = new DefaultEnemyAtackBehaviour(atacker, stubAtackConfig,_playersTransform,
                        transform,GetComponent<IHaveAtackAnimation>());
                else
                    _enemyDefaultAtackBehaviour = new DefaultEnemyAtackBehaviour(atacker, stubAtackConfig,_playersTransform,
                        transform);
            }
            else
                Debug.LogError("нет компонента ICanAtack на " + gameObject.name);   
        }
    }

public abstract class AtackBehaviourContainer : BehaviourContainer<AtackBehaviour<ICanAtack>>
{
}