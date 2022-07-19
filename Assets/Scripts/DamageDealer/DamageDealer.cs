using System.Collections;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private LayerMask _damageTo;
    [SerializeField] private float hitRadius;
    [SerializeField] private float hitDistance;
    [SerializeField] private int countToDamage;
    [Space(15)]
    [Header("Testing")]
    [SerializeField] private bool isTesting;

    private void Start()
    {
        StartCoroutine(TestCor());
    }

    private IEnumerator TestCor()
    {
        while (isTesting)
        {
            yield return new WaitForSeconds(1f);
            AttackSphereCast();
        }
    }

    public void AttackSphereCast()
    {
        float height = transform.position.y + transform.localScale.y;
        Vector3 rayPos = new Vector3(transform.position.x, height, transform.position.z);
        Ray ray = new Ray(rayPos, transform.forward);
        RaycastHit[] hits = new RaycastHit[countToDamage];
        if (Physics.SphereCastNonAlloc(ray, hitRadius, hits, hitDistance, _damageTo) > 0)
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
                        Debug.Log("DamageDealer Erorr at line 43");
#endif
                    }
                }
            }
        }
    }

}
