using UnityEngine;

public class Rotator 
{
    private MousePositionManager _mousePositionManager;
    private Transform _playerTransform;

    public Rotator(Transform playerTransform)
    {
        _playerTransform = playerTransform;
        _mousePositionManager = new MousePositionManager(_playerTransform);
    }

    public void LookAtMouseDirection()
    {
        var position = _mousePositionManager.GetMousePosition();
        _playerTransform.transform.LookAt(new Vector3(position.x, _playerTransform.transform.position.y, position.z));
    }
}
