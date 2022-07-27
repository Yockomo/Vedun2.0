using UnityEngine;

[RequireComponent(typeof(Animator))]
public class StubAnimationComponent : MonoBehaviour, IHaveMoveAnimation, IHaveAtackAnimation
{
    private StubAnimatorManager _stubAnimatorManager;

    private void Awake()
    {
        _stubAnimatorManager = new StubAnimatorManager(GetComponent<Animator>());
    }

    public void SetMoveState(bool value)
    {
        _stubAnimatorManager.SetMoveState(value);
    }

    public bool GetMoveState()
    {
       return _stubAnimatorManager.GetMoveState();
    }

    public void SetIdleState(bool value)
    {
        _stubAnimatorManager.SetIdleState(value);
    }

    public bool GetIdleState()
    {
       return _stubAnimatorManager.GetIdleState();
    }

    public void SetAttackState(bool value)
    {
        _stubAnimatorManager.SetAttackState(value);
    }

    public bool GetAtackState()
    {
        return _stubAnimatorManager.GetAtackState();
    }
}
