using StarterAssets;
using System;

public class PlayerComboAtackBehaviour : AtackBehaviour<ICanAtack>, ICanSetState<AtackStates>
    {
        private StarterAssetsInputs _input;
        
        private PlayerAnimatorManager _animatorManager;

        public event Action OnAtackEventStart;
        public event Action OnAtackEventEnd;

        public PlayerComboAtackBehaviour(ICanAtack attacker, StarterAssetsInputs inputs, PlayerAnimatorManager animatorManager) : base(attacker)
        {
            _input = inputs;
            _animatorManager = animatorManager;
        }

        public void SetState(AtackStates state)
        {
            currentState = state;
        }
        
        public override void Pause()
        {
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
        
        void HandleCurrentState()
        {
            switch (currentState)
            {
                case AtackStates.DEFAULT:
                    HandleFirstAtack();
                    break;
                case AtackStates.ATACK:
                    HandleComboAtack();
                    break;
                case AtackStates.PAUSE:
                    break;
                case AtackStates.UNPAUSE:
                    currentState = AtackStates.DEFAULT;
                    break;
            }
        }

        private void HandleFirstAtack()
        {
            if (PlayerAtack())
            {
                OnAtackEventStart?.Invoke();
                SetAtackState();

                SetState(AtackStates.ATACK);
            }
        }

        private void HandleComboAtack()
        {
            if (PlayerAtack())
            {
                SetAtackState();
            }
        }

        private bool PlayerAtack()
        {
            return _input.atack && _animatorManager.IsGrounded();
        }

        private void SetAtackState()
        {
            _animatorManager.SetAtack();
        }

        private void ResetAtackState()
        {
            _animatorManager.ResetAtack();
        }

        public void NextComboAtack()
        {
            ResetAtackState();
            _animatorManager.SetCombo();
        }

        private void ResetCombo()
        {
            _animatorManager.ResetCombo();
        }

        public void OffCombo()
        {
            OnAtackEventEnd?.Invoke();
            ResetAtackState();
            ResetCombo();
            SetState(AtackStates.DEFAULT);
        }
    }
