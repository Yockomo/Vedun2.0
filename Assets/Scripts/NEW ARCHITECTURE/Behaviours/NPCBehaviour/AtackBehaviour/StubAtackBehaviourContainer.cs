using SOScripts;
using UnityEngine;

    public class StubAtackBehaviourContainer : AtackBehaviourContainer
    {
        [SerializeField] private EnemyAtackConfig stubAtackConfig;

        private DefaultEnemyAtackBehaviour _enemyDefaultAtackBehaviour;
        private ICanSetState<AtackStates> _enemyAtackStatesSetter;
        
        public override AtackBehaviour<ICanAtack> GetValue => _enemyDefaultAtackBehaviour;

        protected override void Init()
        {   
            GetICanAtackComponent();
            GetICanSetAtackStateReference();
        }

        private void GetICanAtackComponent()
        {
            if (TryGetComponent<ICanAtack>(out var atacker))
                _enemyDefaultAtackBehaviour = new DefaultEnemyAtackBehaviour(atacker, stubAtackConfig);
            else
                Debug.LogError("нет компонента ICanAtack на " + gameObject.name);   
        }

        private void GetICanSetAtackStateReference()
        {
            _enemyAtackStatesSetter = _enemyDefaultAtackBehaviour;
        }

        public void SetBehaviourState(AtackStates newState)
        {
            _enemyAtackStatesSetter.SetState(newState);
        }
    }

public abstract class AtackBehaviourContainer : BehaviourContainer<AtackBehaviour<ICanAtack>>
{
}