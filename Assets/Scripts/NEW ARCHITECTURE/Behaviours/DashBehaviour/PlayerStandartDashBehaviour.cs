using StarterAssets;
using UnityEngine;

public class PlayerStandartDashBehaviour : DashBehaviour<IDashable>
{
    private CharacterController _playerController;
    private StarterAssetsInputs _inputs;
    private PlayerAnimatorManager _animatorManager;
    private Camera _mainCamera;
    
    private bool _isDashCooled;
    
    public PlayerStandartDashBehaviour(IDashable dashable,CharacterController controller, StarterAssetsInputs inputs, 
        PlayerAnimatorManager animatorManager, Camera mainCamera) : base(dashable)
    {
        _playerController = controller;
        _inputs = inputs;
        _animatorManager = animatorManager;
        _mainCamera = mainCamera;
    }

    public override void Pause()
    {
        SetState(DashState.PAUSE);
    }

    public override void UnPause()
    {
        SetState(DashState.UNPAUSE);
    }
    
    public override void UpdateBehaviour()
    {
        HandleCurrentState();
    }

    private void HandleCurrentState()
    {
        switch (_currentState)
        {
            case DashState.DEFAULT:
                WaitForDashInputs();
                break;
            case DashState.DASH:
                Dash();
                SetState(DashState.DEFAULT);
                break;
            case DashState.PAUSE:
                break;
            case DashState.UNPAUSE:
                SetState(DashState.DEFAULT);
                break;
        }
    }

    private void WaitForDashInputs()
    {
        if (_inputs.dash && _dashable.IsCooled)
        {
            SetState(DashState.DASH);
        }
    }
    
    private void Dash()
    {
        _animatorManager.SetDash();
        MovePlayersController();
        _dashable.StartCooldown();
    }

    private void MovePlayersController()
    {
        Vector3 inputDirection = new Vector3(_inputs.move.x, 0.0f, _inputs.move.y).normalized;
        var targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                             _mainCamera.transform.eulerAngles.y;
        Vector3 targetDirection = Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward;
        _playerController.Move(targetDirection.normalized * (_dashable.DashSpeed * Time.deltaTime) +
                               new Vector3(0.0f, _playerController.transform.position.y, 0.0f) * Time.deltaTime);
    }
}