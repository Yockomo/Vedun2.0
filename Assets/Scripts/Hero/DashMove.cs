using System.Collections;
using UnityEngine;
using StarterAssets;
using UnityEngine.Events;

public class DashMove : MonoBehaviour
{
    [SerializeField] private float dashTime;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCooldown;

    private ThirdPersonController _personController;
    private StarterAssetsInputs _inputs;
    private AnimatorManager _animatorManager;
    private bool _isDashCooled;

    public UnityEvent UpdateUI;

    private void Start()
    {
        _personController = GetComponent<ThirdPersonController>();
        _inputs = GetComponent<StarterAssetsInputs>();
        _animatorManager = GetComponent<AnimatorManager>();
        _isDashCooled = true;
    }

    void Update()
    {
        if (DashUsed())
        {
            _personController.IsDashing = true;
            _inputs.dash = false;
            _isDashCooled = false;
            _animatorManager.SetDash(true);
            StartCoroutine(TimerCorutine());
            StartCoroutine(DashCorutine());
        }

        if (_personController.IsDashing) Dash();
    }

    private bool DashUsed()
    {
        return _inputs.dash && !_personController.IsDashing && _isDashCooled;
    }

    private void Dash()
    {
        Vector3 targetDirection = Quaternion.Euler(0.0f, _personController._targetRotation, 0.0f) * Vector3.forward;
        _personController.Controller.Move(targetDirection.normalized * (dashSpeed * Time.deltaTime) +
                 new Vector3(0.0f, _personController._verticalVelocity, 0.0f) * Time.deltaTime);
        UpdateUI.Invoke();
    }

    private IEnumerator DashCorutine()
    {
        yield return new WaitForSeconds(dashTime);
        _animatorManager.SetDash(false);
        _personController.IsDashing = false;
    }

    private IEnumerator TimerCorutine()
    {
        yield return new WaitForSeconds(dashCooldown);
        _isDashCooled = true;
    }
}
