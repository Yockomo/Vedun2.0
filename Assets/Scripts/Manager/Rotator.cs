using UnityEngine;
using Zenject;

public class Rotator : MonoBehaviour
{
    private MousePositionManager _mousePositionManager;
    private Transform _playerTransform;

    [Inject]
    private void Construct(MousePositionManager mousePositionManager)
    {
        _mousePositionManager = mousePositionManager;
    }

    private void Start()
    {
        _playerTransform = GetComponent<Transform>();
    }

    public void LookAtMouseDirection()
    {
        var position = _mousePositionManager.GetMousePosition();
        _playerTransform.transform.LookAt(new Vector3(position.x, _playerTransform.transform.position.y, position.z));
    }
}
