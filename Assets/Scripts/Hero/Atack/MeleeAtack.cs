using StarterAssets;
using System;
using UnityEngine;

[RequireComponent(typeof(StarterAssetsInputs),typeof(AnimatorManager))]

public class MeleeAtack : MonoBehaviour
{
    public event Action OnAtackEventStart;
    public event Action OnAtackEventEnd;

    private StarterAssetsInputs _input;
    private AnimatorManager _animatorManager;

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
            OnAtackEventStart?.Invoke();
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
        OnAtackEventEnd?.Invoke();
        ResetAtackState();
        ResetCombo();
    }
}
