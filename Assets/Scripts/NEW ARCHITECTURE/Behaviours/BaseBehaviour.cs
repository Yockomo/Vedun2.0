
public abstract class BaseBehaviour : IBehaviour
{
    public IActor Actor { get; set; }

    public abstract void Pause();

    public abstract void UnPause();

    public abstract void UpdateBehaviour();
}