using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObjects/BasicPlayerStats", order = 1)]
public class BasicPlayerStats : ScriptableObject
{
    public int Level;
    public int Strength;
    public int Agility;
    public int Health;
    public int Energy;
    public float Speed;
    public int Defence;
    public int Luck;
}
