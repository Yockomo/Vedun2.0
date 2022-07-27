public interface IHaveAtackAnimation
{
    public void SetAttackState(bool value);
    public bool GetAtackState();
}

public interface IHaveMoveAnimation : IHaveIdleAnimation
{
    public void SetMoveState(bool value);
    public bool GetMoveState();
}

public interface IHaveIdleAnimation
{
    public void SetIdleState(bool value);
    public bool GetIdleState();
}