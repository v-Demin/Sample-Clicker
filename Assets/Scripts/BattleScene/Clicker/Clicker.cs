using Zenject;

public class Clicker : IInitializable, IEnemyClickHandler, IClickerUpdateHandler
{
    [Inject] private readonly EventBus _eventBus;
    [Inject] private readonly Wallet _wallet;

    public float ClickDamage => _currentLevel * 2;
    public int NextPrice => _currentLevel * 200;
    private int _currentLevel = 1;
    
    public void Initialize()
    {
        _eventBus.Subscribe(this);
        _eventBus.RaiseEvent<ICliclerValuesHandler>(handler => handler.HandleClickerInitialized(_currentLevel, ClickDamage, NextPrice));
    }
    
    public void HandleEnemyClick()
    {
        _eventBus.RaiseEvent<IEnemyDamageHandler>(handler => handler.HandleTakeDamage(ClickDamage));
    }

    public void TryUpgrade(int times = 1)
    {
        for (var i = 0; i < times; i++)
        {
            if (!CheckIsUpdateAvailable()) return;
            
            _eventBus.RaiseEvent<IMoneySpentHandler>(handler => handler.HandleTryToSpendMoney(NextPrice));
            Upgrade();
        }
    }

    private bool CheckIsUpdateAvailable()
    {
        return _wallet.Value >= NextPrice;
    }

    public void ForceUpgrade(int times = 1)
    {
        for (var i = 0; i < times; i++)
        {
            Upgrade();
        }
    }

    private void Upgrade()
    {
        _currentLevel++;
        _eventBus.RaiseEvent<ICliclerValuesHandler>(handler => handler.HandleClickerLevelUpdated(_currentLevel, ClickDamage, NextPrice));
    }
}
