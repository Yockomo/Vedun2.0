using System.Collections;
using UnityEngine;

public class StandartDashComponent : MonoBehaviour, IDashable
{
    [SerializeField] private float dashTime;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCooldown;
    
    public float DashTime => dashTime;
    public float DashSpeed => dashSpeed;
    public float DashCooldown => dashCooldown;

    public bool IsCooled { get; private set; } = true;
    
    public void StartCooldown()
    {
        StartCoroutine(TimerCorutine());
    }

    private IEnumerator TimerCorutine()
    {
        IsCooled = false;
        yield return new WaitForSeconds(dashCooldown);
        IsCooled = true;
    }
}