using UnityEngine;

public class AnimatorManager 
{
    private Animator _animator;

    private readonly int _atack = Animator.StringToHash("Atack");
    private readonly int _combo = Animator.StringToHash("Combo");

    private readonly int _axeThrow = Animator.StringToHash("AxeThrow"); 
    private readonly int _speed = Animator.StringToHash("Speed");
    private readonly int _dash = Animator.StringToHash("Dash");
    private readonly int _grounded = Animator.StringToHash("Grounded");
    private readonly int _dead = Animator.StringToHash("IsDead");

    private readonly int _animIDSpeed = Animator.StringToHash("Speed");
    private readonly int _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
    private readonly int _animIDGrounded = Animator.StringToHash("Grounded");
    private readonly int _animIDJump = Animator.StringToHash("Jump");
    private readonly int _doubleJump = Animator.StringToHash("DoubleJump");
    private readonly int _animIDFreeFall = Animator.StringToHash("FreeFall");

    //If someday backwardRun will be needed
    /*private int _backwardRunLayer =_animator.GetLayerIndex("BackWardRun");*/

    public AnimatorManager(Animator animator)
    {
        _animator = animator;
    }

    public void SetSpeedParameter(float value)
    {
        _animator.SetFloat(_animIDSpeed, value);
    }

    public void SetMotionSpeedParameter(float value)
    {
        _animator.SetFloat(_animIDMotionSpeed, value);
    }

    public void SetGrounded(bool value)
    {
        _animator.SetBool(_animIDGrounded, value);
    }

    public void SetJump(bool value)
    {
        _animator.SetBool(_animIDJump, value);
    }

    public void TriggerDoubleJump()
    {
        _animator.SetTrigger(_doubleJump);
    }

    public void SetFreeFall(bool value)
    {
        _animator.SetBool(_animIDFreeFall, value);
    }

    public void SetAtack()
    {
        _animator.SetTrigger(_atack);
    }

    public void ResetAtack()
    {
        _animator.ResetTrigger(_atack);
    }

    public void SetCombo()
    {
        _animator.SetTrigger(_combo);
    }

    public void ResetCombo()
    {
        _animator.ResetTrigger(_combo);
    }

    public void SetAxeThrow(bool value)
    {
        _animator.SetBool(_axeThrow, value);
    }

    public void SetDash(bool value)
    {
        _animator.SetBool(_dash, value);
    }

    public bool isGrounded()
    {
        return _animator.GetBool(_grounded);
    }

    public void SetDeadAnimation(bool value)
    {
        _animator.SetBool(_dead, value);
    }

    public bool GetAtack()
    {
        return _animator.GetBool(_atack);
    }

    public float GetSpeed()
    {
        return _animator.GetFloat(_speed);
    }

    //public void SetBackwardRun(bool value)
    //{
    //    var layerWeight = value ? 1 : 0;
    //    _animator.SetLayerWeight(_backwardRunLayer, layerWeight);
    //}
}
