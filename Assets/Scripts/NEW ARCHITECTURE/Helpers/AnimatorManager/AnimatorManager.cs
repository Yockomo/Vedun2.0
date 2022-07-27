using UnityEngine;

public abstract class AnimatorManager
{
    protected Animator _animator;

    protected AnimatorManager(Animator animator)
    {
        _animator = animator;
    }
}