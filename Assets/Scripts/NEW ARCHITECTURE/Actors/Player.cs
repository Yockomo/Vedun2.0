
using StarterAssets;
using System;
using UnityEngine;

public class Player : Actor, ICanAtack
{
    private StarterAssetsInputs _playerInputs;
    private AnimationEvents _eventsPlayedOnAtackAnimation;

    private AnimatorManager _playersAnimatorManager;
    private MousePositionManager _mousePositionManager;

    private PlayerComboAtackBehaviour _meleeAtackBehaviour;

    protected override void Init()
    {
        _playerInputs = GetComponent<StarterAssetsInputs>();
        _eventsPlayedOnAtackAnimation = GetComponent<AnimationEvents>();

        _mousePositionManager = new MousePositionManager(transform);
        _playersAnimatorManager = new AnimatorManager(GetComponent<Animator>());

        if(TryGetComponent<ICanAtack>(out ICanAtack atacker))
        {
            _meleeAtackBehaviour = new PlayerComboAtackBehaviour(atacker, _playerInputs, _playersAnimatorManager);
            AddBehaviour(_meleeAtackBehaviour);
            _eventsPlayedOnAtackAnimation.NextComboAtackEvent += _meleeAtackBehaviour.NextComboAtack;
            _eventsPlayedOnAtackAnimation.OffComboEvent += _meleeAtackBehaviour.OffCombo;
        }

        if (TryGetComponent<IMoveAndRotate>(out IMoveAndRotate movable))
        {
            var moveBehaviour = new PlayerStandartMoveBehaviour(movable, GetComponent<StarterAssetsInputs>(),
                GetComponent<CharacterController>(), _playersAnimatorManager);
            FollowMeleeAtackStartEvent(_meleeAtackBehaviour, moveBehaviour.SetAtackState);
            FollowMeleeAtackEndEvent(_meleeAtackBehaviour, moveBehaviour.SetDefaultState);
            AddBehaviour(moveBehaviour);

            var rotateBehaviour = new PlayerStandartRotateBehaviour(movable, _mousePositionManager, GetComponent<StarterAssetsInputs>());
            FollowMeleeAtackStartEvent(_meleeAtackBehaviour,rotateBehaviour.SetAtackState);
            FollowMeleeAtackEndEvent(_meleeAtackBehaviour,rotateBehaviour.SetDefaultState);
            AddBehaviour(rotateBehaviour);
        }
        else
            Debug.LogError("нет компонента перемещения у " + gameObject.name);
    }

    private void FollowMeleeAtackStartEvent(PlayerComboAtackBehaviour meleeAtack,Action someMethod)
    {
        meleeAtack.OnAtackEventStart += someMethod;
    }    
    
    private void FollowMeleeAtackEndEvent(PlayerComboAtackBehaviour meleeAtack,Action someMethod)
    {
        meleeAtack.OnAtackEventEnd += someMethod;
    }
}
