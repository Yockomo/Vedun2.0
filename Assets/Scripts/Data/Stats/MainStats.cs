
public struct MainStats
{
    public float Health { get;  private set; }
    public float Energy { get;  private set; }
    public float Strength { get;  private set; }
    public float Agility { get;  private set; }
    public float Defence { get;  private set; }

    public MainStats(float health, float energy, float strength, float agility, float defence) 
    {
        Health = health;
        Energy = energy;
        Strength = strength;
        Agility = agility;
        Defence = defence;
    }

    public void ChangeHealthStat(float value) 
    {
        Health += value;
    }

    public void ChangeEnergyStat(float value)
    {
        Energy += value;
    }

    public void ChangeStrength(float value)
    {
        Strength += value;
    }

    public void ChangeAgilityStat(float value)
    {
        Agility += value;
    }

    public void ChangeDefenceStat(float value)
    {
        Defence += value;
    }
}