public interface IDashable : IHaveCooldown
{
  float DashTime { get; }
  float DashSpeed { get; }
  float DashCooldown { get; }
}

public interface IHaveCooldown
{
  bool IsCooled { get; }
  void StartCooldown();
}