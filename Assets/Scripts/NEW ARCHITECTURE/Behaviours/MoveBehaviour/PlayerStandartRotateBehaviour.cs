using StarterAssets;
using UnityEngine;

public class PlayerStandartRotateBehaviour : MoveBehaviour<IMoveAndRotate>
{
    private MousePositionManager _mousePositionManager;
    private StarterAssetsInputs _input;
    private Camera _mainCamera;

    private float _targetRotation;
    private float _rotationVelocity;

    public PlayerStandartRotateBehaviour(IMoveAndRotate movable,MousePositionManager mousePositionManager, StarterAssetsInputs inputs ) : base(movable)
    {
        _mousePositionManager = mousePositionManager;
        _input = inputs;
        _mainCamera = Camera.main;
    }

    public override void Pause()
    {
        _currentState = MoveState.PAUSE;
    }

    public override void UnPause()
    {
        _currentState = MoveState.UNPAUSE;
    }

    public override void UpdateBehaviour()
    {
        HandleCurrentState();
    }

    private void HandleCurrentState()
    {
        switch (_currentState)
        {
            case MoveState.DEFAULT:
                Rotate();
                break;
            case MoveState.ATACK:
                break;
            case MoveState.PAUSE:
                break;
            case MoveState.UNPAUSE:
                _currentState = MoveState.DEFAULT;
                break;
        }
    }

    private void Rotate()
    {
        if (_input.move != Vector2.zero)
        {
            Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;
            _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                              _mainCamera.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(_movable.Transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                _movable.RotationSmoothTime);

            _movable.Transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }
    }

    private void LookAtMouseDirection()
    {
        var position = _mousePositionManager.GetMousePosition();
        _movable.Transform.LookAt(new Vector3(position.x, _movable.Transform.position.y, position.z));
    }

    //TODO реализовать нормальное переключение стейтов
    public void SetAtackState()
    {
        //повернуться в сторону камеры в начале атаки
        LookAtMouseDirection();
        _currentState = MoveState.ATACK;
    }

    public void SetDefaultState()
    {
        _currentState = MoveState.DEFAULT;
    }
}
