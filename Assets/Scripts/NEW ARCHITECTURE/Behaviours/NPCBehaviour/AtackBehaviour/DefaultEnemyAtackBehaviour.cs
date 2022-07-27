    using UnityEngine;

    public class DefaultEnemyAtackBehaviour : AtackBehaviour<ICanAtack>, ICanSetState<AtackStates>
    {
        private EnemyMovementAndAtackConfig _atackConfig;
        
        private Transform _playersTransform;
        private Transform _attackerTransform;
        private float _distanceToTarget;
        
        private bool _haveAnimator;
        private IHaveAtackAnimation _atackAnimation;

        public DefaultEnemyAtackBehaviour(ICanAtack attacker, EnemyMovementAndAtackConfig atackConfig,Transform playersTransform,
            Transform attackerTransform) : base(attacker)
        {
            GetNecessaryDependencies(atackConfig,playersTransform,attackerTransform);
        }
        
        public DefaultEnemyAtackBehaviour(ICanAtack attacker, EnemyMovementAndAtackConfig atackConfig,Transform playersTransform,
            Transform attackerTransform,IHaveAtackAnimation atackAnimation) : base(attacker)
        {
            GetNecessaryDependencies(atackConfig,playersTransform,attackerTransform);
            _atackAnimation = atackAnimation;
            _haveAnimator = true;
        }
        
        private void GetNecessaryDependencies(EnemyMovementAndAtackConfig atackConfig, Transform playersTransform,Transform attackerTransform)
        {
            _atackConfig = atackConfig;
            _playersTransform = playersTransform;
            _attackerTransform = attackerTransform;
        }
        
        public void SetState(AtackStates state)
        {
            currentState = state;
        }
        
        public override void Pause()
        {
            StopAtack();
            SetState(AtackStates.PAUSE);
        }

        public override void UnPause()
        {
            SetState(AtackStates.UNPAUSE);
        }
        
        public override void UpdateBehaviour()
        {
            HandleCurrentState();  
        }

        private void HandleCurrentState()
        {
            _distanceToTarget = Vector3.Distance(_attackerTransform.position, _playersTransform.position);
            
            switch (currentState)
            {
                case AtackStates.DEFAULT:
                    DefaultState();
                    break;
                case AtackStates.ATACK:
                    AttackState();
                    break;
                case AtackStates.PAUSE:
                    break;
                case AtackStates.UNPAUSE:
                    SetState(AtackStates.DEFAULT);
                    break;
            }
        }

        private void DefaultState()
        {
            StopAtack();
            
            if (CloseToTarget())
            {
                return;
            }
            
            SetState(AtackStates.ATACK);
        }

        private void AttackState()
        {
            Atack();
            
            if (!CloseToTarget())
            {
                return;
            }
            
            SetState(AtackStates.DEFAULT);
        }

        private bool CloseToTarget()
        {
            return _distanceToTarget > _atackConfig.StoppingDistance;
        }

        private void Atack()
        {
            SetAttack(true);
        }

        private void StopAtack()
        {
            SetAttack(false);
        }
        
        private void SetAttack(bool state)
        {
            if (_haveAnimator && _atackAnimation.GetAtackState() != state)
            {
                _atackAnimation.SetAttackState(state);
            }
        }
    }