using StarterAssets;
using System;
using UnityEngine;

public class Player : Actor, ICanAtack
{
    private StarterAssetsInputs _playerInputs;
    private AnimationEvents _eventsPlayedOnAtackAnimation;

    private PlayerAnimatorManager _playersAnimatorManager;
    private MousePositionManager _mousePositionManager;

    private PlayerComboAtackBehaviour _meleeAtackBehaviour;

    protected override void Init()
    {
        GetComponents();
        _mousePositionManager = new MousePositionManager(transform);
        _playersAnimatorManager = new PlayerAnimatorManager(GetComponent<Animator>());

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
            AddAtackStartEndEventsAndBehaviour(moveBehaviour, _meleeAtackBehaviour, moveBehaviour.SetAtackState,
                moveBehaviour.SetDefaultState);

            var rotateBehaviour = new PlayerStandartRotateBehaviour(movable, _mousePositionManager, GetComponent<StarterAssetsInputs>());
            AddAtackStartEndEventsAndBehaviour(rotateBehaviour, _meleeAtackBehaviour, rotateBehaviour.SetAtackState,
                rotateBehaviour.SetDefaultState);
        }
        else
            Debug.LogError("��� ���������� ����������� � " + gameObject.name);
        
        AddBehaviour(CreateDashBehaviour());
    }

    private void GetComponents()
    {
        _playerInputs = GetComponent<StarterAssetsInputs>();
        _eventsPlayedOnAtackAnimation = GetComponent<AnimationEvents>();
    }

    private void AddAtackStartEndEventsAndBehaviour(IBehaviour behaviour,PlayerComboAtackBehaviour _meleeAtackBehaviour, Action onAtackStartAction, Action onAtackEndAction)
    {
        _meleeAtackBehaviour.OnAtackEventStart += onAtackStartAction;
        _meleeAtackBehaviour.OnAtackEventEnd += onAtackEndAction;
        AddBehaviour(behaviour);
    }
    
    private PlayerStandartDashBehaviour CreateDashBehaviour()
    {
        if (TryGetComponent<IDashable>(out var dashable))
        {
            return new PlayerStandartDashBehaviour(dashable, GetComponent<CharacterController>(),
                GetComponent<StarterAssetsInputs>(), _playersAnimatorManager, Camera.main);
        }
        else
            Debug.LogError("There is no dashable component on " + gameObject.name);

        return null;
    }
}
