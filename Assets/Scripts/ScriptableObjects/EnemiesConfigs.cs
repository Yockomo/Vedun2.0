using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesConfig", menuName = "ScriptableObject/EnemiesConfigs", order = 1)]
public class EnemiesConfigs : ScriptableObject
{
    public float sightAngle = 0.3f;

    [Header("Likho")]
    public float likhoReactDistance;
    public float likhoStoppingDistance;
    public float likhoSpeed;
    [Range(0,1)] public float likhoSpecialAttackChance;
    public float likhoSpecialAttackCooldownTime;
    public float likhoSpecialAttackDelay;
    public int likhoSpecialAttackDamage;
    public int likhoDamage;
    public int likhoHealth;

    [Header("CyberGiant")]
    public float giantReactDistance;
    public float giantStoppingDistance;
    public float giantSpeed;
    [Range(0, 1)] public float giantSpecialAttackChance;
    public float giantSpecialAttackCooldownTime;
    public float giantSpecialAttackDelay;
    public int giantSpecialAttackDamage;
    public int giantDamage;
    public int giantHealth;

    [Header("Sniper")]
    public float sniperReactDistance;
    public float sniperStoppingDistance;
    public float sniperSpeed;
    [Range(0, 1)] public float sniperSpecialAttackChance;
    public float sniperSpecialAttackCooldownTime;
    public float sniperSpecialAttackDelay;
    public int sniperSpecialAttackDamage;
    public int sniperDamage;
    public int sniperHealth;

    [Header("Normal")]
    public float normalReactDistance;
    public float normalStoppingDistance;
    public float normalSpeed;
    [Range(0, 1)] public float normalSpecialAttackChance;
    public float normalSpecialAttackCooldownTime;
    public float normalSpecialAttackDelay;
    public int normalSpecialAttackDamage;
    public int normalDamage;
    public int normalHealth;
}
