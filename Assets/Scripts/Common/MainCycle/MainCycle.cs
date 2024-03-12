using Zenject;

public class MainCycle : IInitializable
{
    [Inject] private readonly DiContainer _container;

    public void Initialize()
    {

    }
}
