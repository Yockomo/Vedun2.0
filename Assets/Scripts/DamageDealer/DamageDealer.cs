using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private BasicAxeStats basicAxeStats;
    [SerializeField] private BasicPlayerStats basicPlayerStats;
    [SerializeField] private LayerMask damageTo;
    [SerializeField] private float hitRadius;
    [SerializeField] private float hitDistance;
    [SerializeField] private int countToDamage;

    private int damage;
    
    private void Start() {
        if (basicAxeStats != null && basicPlayerStats != null) {
            damage = RecalculateDamage();
        }
    }

    public int RecalculateDamage() {
        return basicAxeStats.Damage + basicPlayerStats.Strength;
    }

    public void Attack()
    {
        DamageSphereCast damageSphereCast = new DamageSphereCast();
        damageSphereCast.AttackSphereCast(this.transform, damage, hitDistance, hitRadius, countToDamage, damageTo);
    }
    
    public void ComboAttack()
    {
        int comboDamage =  (int)Mathf.Ceil(damage * 1.5f);
        DamageSphereCast damageSphereCast = new DamageSphereCast();
        damageSphereCast.AttackSphereCast(this.transform, comboDamage, hitDistance, hitRadius, countToDamage, damageTo);
    }
}
