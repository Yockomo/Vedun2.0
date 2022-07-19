using UnityEngine;
using UnityEngine.InputSystem;

public class MousePositionManager 
{
    private Transform _playerTransform;

    public MousePositionManager(Transform playerTransform )
    {
        _playerTransform = playerTransform;
    }

    public Vector3 GetMousePosition()
    {
        return GetRaycastHit();
    }

    private Vector3 GetRaycastHit()
    {
        Ray ray = Camera.main.ScreenPointToRay(CalculateMousePosition());
        if (Physics.Raycast(ray, out var raycastHit, 999f))
        {
            return raycastHit.point;
        }
        return _playerTransform.forward;
    }

    private Vector3 CalculateMousePosition()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = _playerTransform.transform.position.z;
        return mousePos;
    }

    public float GetAngleBetweenMouseAndPlayer()
    {
        Vector3 directionVector = CalculateDirectionVector();
        float angle = Vector3.Angle(directionVector, _playerTransform.transform.forward);
        return angle;
    }

    private Vector3 CalculateDirectionVector()
    {
        Vector2 inputVector = _playerTransform.GetComponent<StarterAssets.StarterAssetsInputs>().move;
        var second = new Vector3(_playerTransform.transform.position.x, 0, _playerTransform.transform.position.z)
            + new Vector3(inputVector.x, _playerTransform.transform.position.y, inputVector.y);
        return second - _playerTransform.transform.position;
    }
}
