using StarterAssets;
using System;
using System.Collections;
using UnityEngine;

public class PlayerComboAtackBehaviour : AtackBehaviour<ICanAtack>, ICanSetState<AtackStates>
    {
        private StarterAssetsInputs _input;
        private CharacterController _playersController;
        private PlayerAnimatorManager _animatorManager;

        private float moveDistance = 1;
        
        public event Action OnAtackEventStart;
        public event Action OnAtackEventEnd;

        public PlayerComboAtackBehaviour(ICanAtack attacker, StarterAssetsInputs inputs, PlayerAnimatorManager animatorManager,
            CharacterController _controller) : base(attacker)
        {
            _input = inputs;
            _animatorManager = animatorManager;
            _playersController = _controller;
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

        public void OffCombo()
        {
            OnAtackEventEnd?.Invoke();
            ResetAtackState();
            ResetCombo();
            SetState(AtackStates.DEFAULT);
        }
        
        private void ResetCombo()
        {
            _animatorManager.ResetCombo();
        }

        public IEnumerator MoveOnAttack()
        {
            var lastPlayerPos = _playersController.transform.position;
            while (Vector3.Distance(lastPlayerPos, _playersController.transform.position) < moveDistance)
            {
                yield return new WaitForFixedUpdate();
                _playersController.Move(_playersController.transform.forward * Time.deltaTime);
            }
        }
    }
