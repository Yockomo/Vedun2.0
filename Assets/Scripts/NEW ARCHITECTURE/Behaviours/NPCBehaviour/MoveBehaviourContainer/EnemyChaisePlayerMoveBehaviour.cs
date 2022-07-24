using UnityEngine;
using UnityEngine.AI;

public class EnemyChaisePlayerMoveBehaviour : MoveBehaviour<IMoveAndRotate>
    {
        private readonly EnemyChaiseMoveConfig _enemyChaiseMoveConfig;
        private Transform _playersTransform;
        private NavMeshAgent _navMeshAgent;

        private float _distanceToTarget;
        
        public EnemyChaisePlayerMoveBehaviour(IMoveAndRotate movable, EnemyChaiseMoveConfig enemyChaiseMoveConfig, 
            Transform playersTransform, NavMeshAgent navmeshAgent) : base(movable)
        {
            _enemyChaiseMoveConfig = enemyChaiseMoveConfig;
            _playersTransform = playersTransform;
            _navMeshAgent = navmeshAgent;
        }

        public override void Pause()
        {
            currentState = MoveState.PAUSE;
        }

        public override void UnPause()
        {
            currentState = MoveState.UNPAUSE;
        }
        
        public override void UpdateBehaviour()
        {
            HandleCurrentState();
        }
        
        private void HandleCurrentState()
        {
            _distanceToTarget = Vector3.Distance(movable.Transform.position, _playersTransform.position);
            
            switch (currentState)
            {
                case(MoveState.DEFAULT):
                    DefaultState();
                    break;
                case(MoveState.ATACK):
                    AtackState();
                    break;                
                case(MoveState.PAUSE):
                    StopMovement(false);
                    break;                
                case(MoveState.UNPAUSE):
                    StopMovement(true);
                    currentState = MoveState.DEFAULT;
                    break;
            }
        }
        
        private void DefaultState()
        {
            if (_distanceToTarget > _enemyChaiseMoveConfig.ReactDistance)
            {
                return;
            }

            currentState = MoveState.ATACK;
        }

        private void AtackState()
        {
            if (_distanceToTarget > _enemyChaiseMoveConfig.StoppingDistance)
            {
                ChaisePlayer();
                return;
            }
            
            StopMovement(true);
        }

        private void ChaisePlayer()
        {
            StopMovement(false);
            SetSpeed(movable.MoveSpeed);
            SetDestination(_playersTransform.position);
        }
        
        private void StopMovement (bool value)
        {
            _navMeshAgent.isStopped = value;
        }

        private void SetSpeed(float value)
        {
            _navMeshAgent.speed = value;
        }

        private void SetDestination(Vector3 targetPoint)
        {
            _navMeshAgent.SetDestination(targetPoint);
        }
    }