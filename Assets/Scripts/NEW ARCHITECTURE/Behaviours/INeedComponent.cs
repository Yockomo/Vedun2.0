
public interface INeedComponent<T> where T : IComponent
{
    void GetNeededCompoent(T component);
}

public interface IComponent
{
}