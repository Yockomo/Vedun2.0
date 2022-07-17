using StarterAssets;
using UnityEngine;

[RequireComponent(typeof(StarterAssetsInputs),typeof(AnimatorManager))]

public class MeleeAtack : MonoBehaviour
{
    private StarterAssetsInputs _input;
    private AnimatorManager _animatorManager;
    private Rotator _rotationBehaviour;
    private BackwardRunHandler _backwardRunHandler;

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _animatorManager = GetComponent<AnimatorManager>();
        _rotationBehaviour = GetComponent<Rotator>();
        _backwardRunHandler = GetComponent<BackwardRunHandler>();
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

    //to reset state in first frame of Atack animation by AnimationEvent
    public void resetAtackState()
    {
        SetAtackStateAndCheckBackwardRun(false);
    }

    private void SetAtackStateAndCheckBackwardRun(bool atackState)
    {
        _animatorManager.SetAtack(atackState);
        _backwardRunHandler.CheckBackwardRun();
    }
}
