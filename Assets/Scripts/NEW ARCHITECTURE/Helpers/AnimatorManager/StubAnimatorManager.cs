using UnityEditorInternal;
using UnityEngine;

public class StubAnimatorManager: AnimatorManager, IHaveAtackAnimation, IHaveMoveAnimation
{
    private readonly int _idle = Animator.StringToHash("Idle");
    private readonly int _move = Animator.StringToHash("Move");
    private readonly int _attack = Animator.StringToHash("Attack");
    private readonly int _attackSpeed = Animator.StringToHash("AttackSpeed");
    private readonly int _death = Animator.StringToHash("Death");
    private readonly int _revive = Animator.StringToHash("Revive");
        
    public StubAnimatorManager(Animator animator) : base(animator)
    {
    }

    public void SetIdleState(bool value)
    {
        _animator.SetBool(_idle,value);
    }

    public bool GetIdleState()
    {
        return _animator.GetBool(_idle);
    }

    public void SetMoveState(bool value)
    {
        _animator.SetBool(_move,value);
    }

    public bool GetMoveState()
    {
        return _animator.GetBool(_move);
    }

    public void SetAttackState(bool value)
    {
        _animator.SetBool(_attack,value);
    }

    public bool GetAtackState()
    {
        return _animator.GetBool(_attack);
    }


    public void SetAttackSpeed(float value)
    {
        _animator.SetFloat(_attackSpeed,value);
    }

    public void SetTriggerDeathState()
    {
        _animator.SetTrigger(_death);
    }    
    
    public void ResetTriggerDeathState()
    {
        _animator.ResetTrigger(_death);
    }
    
    public void SetTriggerReviveState()
    {
        _animator.SetTrigger(_revive);
    }    
    
    public void ResetTriggerReviveState()
    {
        _animator.ResetTrigger(_revive);
    }
}