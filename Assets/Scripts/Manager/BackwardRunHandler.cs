using UnityEngine;

public class BackwardRunHandler 
{
    private MousePositionManager _mousePositionManager;
    private AnimatorManager _animatorManager;
    private const int AngleOfView = 90;

    public BackwardRunHandler(Transform playerTransform, AnimatorManager animatorManager)
    {
        _mousePositionManager = new MousePositionManager(playerTransform);
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
