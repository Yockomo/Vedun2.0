using System.Collections;
using UnityEngine;
using StarterAssets;
using UnityEngine.Events;

public class DashMove : MonoBehaviour
{
    [SerializeField] private float dashTime;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCooldown;

    private ThirdPersonController personController;
    private StarterAssetsInputs inputs;
    private Animator animator;
    private int baseLayer;
    private bool isDashCooled;

    public UnityEvent UpdateUI;

    private void Start()
    {
        personController = GetComponent<ThirdPersonController>();
        inputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
        baseLayer = animator.GetLayerIndex("Base Layer");
        isDashCooled = true;
    }

    void Update()
    {
        if (DashUsed())
        {
            personController.IsDashing = true;
            inputs.dash = false;
            isDashCooled = false;
            animator.SetLayerWeight(baseLayer,0f);
            animator.SetBool("Dash", true);
            StartCoroutine(TimerCorutine());
            StartCoroutine(DashCorutine());
        }

        if (personController.IsDashing) Dash();
    }

    private bool DashUsed()
    {
        return inputs.dash && !personController.IsDashing && isDashCooled;
    }

    private void Dash()
    {
        Vector3 targetDirection = Quaternion.Euler(0.0f, personController._targetRotation, 0.0f) * Vector3.forward;
        personController.Controller.Move(targetDirection.normalized * (dashSpeed * Time.deltaTime) +
                 new Vector3(0.0f, personController._verticalVelocity, 0.0f) * Time.deltaTime);
        UpdateUI.Invoke();
    }

    private IEnumerator DashCorutine()
    {
        yield return new WaitForSeconds(dashTime);
        animator.SetBool("Dash", false);
        animator.SetLayerWeight(baseLayer, 1f);
        personController.IsDashing = false;
    }

    private IEnumerator TimerCorutine()
    {
        yield return new WaitForSeconds(dashCooldown);
        isDashCooled = true;
    }
}
