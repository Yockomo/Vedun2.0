
public interface IBehaviour
{
    IActor Actor { get; set; }

    void UpdateBehaviour();
    void Pause();
    void UnPause();
}
