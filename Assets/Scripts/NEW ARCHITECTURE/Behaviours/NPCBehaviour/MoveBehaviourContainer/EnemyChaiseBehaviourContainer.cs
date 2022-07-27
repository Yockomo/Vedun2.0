using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(NavMeshAgent))]
    public class EnemyChaiseBehaviourContainer : MoveBehaviourContainer
    {
        [SerializeField] private EnemyMovementAndAtackConfig enemyMoveConfig = default;
        [SerializeField] private bool animateMovement;
        
        private EnemyChaisePlayerMoveBehaviour _enemyChaisePlayerLogic;
        private Transform _playersTransform;
        
        public override IMoveBehaviour GetValue => _enemyChaisePlayerLogic;

        [Inject]
        private void Construct(Player player)
        {
            _playersTransform = player.GetComponent<Transform>();
        }
        
        protected override void Init()
        {
            if (TryGetComponent<IMoveAndRotate>(out var movable))
            {
                if(animateMovement)
                    _enemyChaisePlayerLogic = new EnemyChaisePlayerMoveBehaviour
                    (movable, enemyMoveConfig, _playersTransform, GetComponent<NavMeshAgent>(),GetComponent<IHaveMoveAnimation>());
                else
                {
                    _enemyChaisePlayerLogic = new EnemyChaisePlayerMoveBehaviour
                        (movable, enemyMoveConfig, _playersTransform, GetComponent<NavMeshAgent>());
                }
            }
            else
                Debug.LogError("нет компонента Movable или IHaveMoveAnimation на " + gameObject.name);
        }
    }
