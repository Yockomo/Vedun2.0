using StarterAssets;
using UnityEngine;

[RequireComponent(typeof(StarterAssetsInputs),typeof(AnimatorManager))]

public class MeleeAtack : MonoBehaviour
{
    private StarterAssetsInputs _input;
    private AnimatorManager _animatorManager;
    private Rotator _rotationBehaviour;
    private BackwardRunHandler _backwardRunBehaviour;

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _animatorManager = GetComponent<AnimatorManager>();
        _rotationBehaviour = new Rotator(transform);
        _backwardRunBehaviour = new BackwardRunHandler(transform, _animatorManager);
    }

    void Update()
    {
        HandleAtack();
    }

    private void HandleAtack()
    {
        if (_input.atack && _animatorManager.isGrounded())
        {
            _rotationBehaviour.LookAtMouseDirection();
            SetAtackStateAndCheckBackwardRun(true);
        }
    }

    private void SetAtackStateAndCheckBackwardRun(bool atackState)
    {
        _animatorManager.SetAtack(atackState);
        _backwardRunBehaviour.CheckBackwardRun();
    }

    //to reset state in first frame of Atack animation by AnimationEvent
    public void resetAtackState()
    {
        SetAtackStateAndCheckBackwardRun(false);
    }
}
