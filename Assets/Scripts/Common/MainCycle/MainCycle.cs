using Zenject;

public class MainCycle : IInitializable
{
    [Inject] private readonly DiContainer _container;

    private Wallet _wallet;
    private Clicker _clicker;
    
    public void Initialize()
    {
        _clicker = _container.Instantiate<Clicker>();
        _wallet = _container.Instantiate<Wallet>();
        
        _clicker.Init();
        _wallet.Init();
    }
}
