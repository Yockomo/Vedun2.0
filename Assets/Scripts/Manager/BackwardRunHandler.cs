using UnityEngine;
using Zenject;

public class BackwardRunHandler : MonoBehaviour
{
    private MousePositionManager _mousePositionManager;
    private AnimatorManager _animatorManager;
    private const int AngleOfView = 90;

    [Inject]
    private void Construct(MousePositionManager mouseManager, AnimatorManager animatorManager)
    {
        _mousePositionManager = mouseManager;
        _animatorManager = animatorManager;
    }

    public void CheckBackwardRun()
    {
        if (_animatorManager.GetSpeed() > 0 && _animatorManager.isGrounded())
        {
            var backward = _mousePositionManager.GetAngleBetweenMouseAndPlayer() > AngleOfView;
            _animatorManager.SetBackwardRun(backward);
        }
    }
}
