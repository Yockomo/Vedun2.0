using UnityEngine;
using UnityEngine.AI;

public class EnemyChaisePlayerMoveBehaviour : MoveBehaviour<IMoveAndRotate>, ICanSetState<MoveState>
{
    private EnemyChaiseMoveConfig _enemyChaiseMoveConfig;

    private Transform _playersTransform;
    private NavMeshAgent _navMeshAgent;
    private IHaveMoveAnimation _moveAnimation;
    private bool _haveAnimator;
    
    private float _distanceToTarget;

    public EnemyChaisePlayerMoveBehaviour(IMoveAndRotate movable, EnemyChaiseMoveConfig enemyChaiseMoveConfig,
        Transform playersTransform, NavMeshAgent navmeshAgent, IHaveMoveAnimation moveAnimation) : base(movable)
    {
        GetNecessaryDependencies(enemyChaiseMoveConfig,playersTransform,navmeshAgent);
        _moveAnimation = moveAnimation;
        _haveAnimator = true;
    }
    
    public EnemyChaisePlayerMoveBehaviour(IMoveAndRotate movable, EnemyChaiseMoveConfig enemyChaiseMoveConfig,
        Transform playersTransform, NavMeshAgent navmeshAgent) : base(movable)
    {
        GetNecessaryDependencies(enemyChaiseMoveConfig,playersTransform,navmeshAgent);
    }

    private void GetNecessaryDependencies(EnemyChaiseMoveConfig enemyChaiseMoveConfig,
        Transform playersTransform, NavMeshAgent navmeshAgent)
    {
        _enemyChaiseMoveConfig = enemyChaiseMoveConfig;
        _playersTransform = playersTransform;
        _navMeshAgent = navmeshAgent;
    }
    
    public override void Pause()
    {
        SetState(MoveState.PAUSE);
    }

    public override void UnPause()
    {
        SetState(MoveState.UNPAUSE);
    }

    public void SetState(MoveState state)
    {
        currentState = state;
    }

    public override void UpdateBehaviour()
    {
        HandleCurrentState();
    }

    private void HandleCurrentState()
    {
        _distanceToTarget = Vector3.Distance(movable.Transform.position, _playersTransform.position);

        switch (currentState)
        {
            case (MoveState.DEFAULT):
                DefaultState();
                break;
            case (MoveState.ATACK):
                AtackState();
                break;
            case (MoveState.PAUSE):
                StopMovement(false);
                break;
            case (MoveState.UNPAUSE):
                StopMovement(true);
                SetState(MoveState.DEFAULT);
                break;
        }
    }

    private void DefaultState()
    {
        if (_distanceToTarget > _enemyChaiseMoveConfig.ReactDistance)
        {
            return;
        }

        SetState(MoveState.ATACK);
    }

    private void AtackState()
    {
        if (_distanceToTarget > _enemyChaiseMoveConfig.StoppingDistance)
        {
            ChaisePlayer();
            return;
        }
        
        StopMovement(true);
    }

    private void ChaisePlayer()
    {
        StopMovement(false);
        SetSpeed(movable.MoveSpeed);
        SetDestination(_playersTransform.position);
    }

    private void StopMovement(bool value)
    {
        _navMeshAgent.isStopped = value;
        if (_haveAnimator)
        {
            StopMovementAnimation(value);
            StartIdleAnimation(value);   
        }
    }

    private void StopMovementAnimation(bool value)
    {
        if(_moveAnimation.GetMoveState() != !value)
            _moveAnimation.SetMoveState(!value);
    }

    private void StartIdleAnimation(bool value)
    {
        if(_moveAnimation.GetIdleState() != value)
            _moveAnimation.SetIdleState(value);
    }
    
    private void SetSpeed(float value)
    {
        _navMeshAgent.speed = value;
    }

    private void SetDestination(Vector3 targetPoint)
    {
        _navMeshAgent.SetDestination(targetPoint);
    }
}