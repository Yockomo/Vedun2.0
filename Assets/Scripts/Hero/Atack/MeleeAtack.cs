using StarterAssets;
using System;
using UnityEngine;

[RequireComponent(typeof(StarterAssetsInputs))]

public class MeleeAtack : MonoBehaviour
{
    public event Action OnAtackEventStart;
    public event Action OnAtackEventEnd;

    private StarterAssetsInputs _input;
    private AnimatorManager _animatorManager;

    private bool _isAtacking;

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _animatorManager = GetComponent<AnimatorManager>();
    }

    void Update()
    {
        HandleAtack();
    }

    private void HandleAtack()
    {
        if (_input.atack && _animatorManager.isGrounded())
        {
            if(!_isAtacking)
            {
                _isAtacking = true;
                OnAtackEventStart?.Invoke();
            }
            SetAtackState();
        }
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
        _isAtacking = false;    
        OnAtackEventEnd?.Invoke();
        ResetAtackState();
        ResetCombo();
    }
}
