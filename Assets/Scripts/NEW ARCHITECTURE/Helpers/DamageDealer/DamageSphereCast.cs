using UnityEngine;

public class DamageSphereCast
{
    public void AttackSphereCast(Transform dealerTransform, int damage, float hitDistance, float hitRadius, int countToDamage,LayerMask damageTo)
    {
        float height = dealerTransform.position.y + dealerTransform.localScale.y;
        Vector3 rayPos = new Vector3(dealerTransform.position.x, height, dealerTransform.position.z);
        Ray ray = new Ray(rayPos, dealerTransform.forward);
        RaycastHit[] hits = new RaycastHit[countToDamage];
        if (Physics.SphereCastNonAlloc(ray, hitRadius, hits, hitDistance, damageTo) > 0)
        {
            foreach (RaycastHit hit in hits)
            {
                if (hit.transform != null && hit.transform.TryGetComponent<IHealthChanger>(out IHealthChanger changable))
                {
                    try
                    {
                        changable.DecValue(damage);
#if (UNITY_EDITOR)
                        Debug.Log("hit " + hit.transform.name);
#endif
                    }
                    catch
                    {
#if (UNITY_EDITOR)
                        Debug.Log("DamageDealer can't take HEALTH");
#endif
                    }
                }
            }
        }
    }
}
