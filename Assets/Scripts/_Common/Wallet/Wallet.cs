using Zenject;

public class Wallet : IInitializable, IMoneyEarnedHandler, IMoneySpentHandler
{
    [Inject] private readonly EventBus _eventBus;
    
    public int Value => _value;
    private int _value;

    public void Initialize()
    {
        _eventBus.Subscribe(this);
        _eventBus.RaiseEvent<IMoneyValueHandler>(handler => handler.HandleMoneyInitialized(_value));
    }
    
    public void HandleTryToSpendMoney(int value)
    {
        if (_value < value) return;

        _value -= value;
        _eventBus.RaiseEvent<IMoneyValueHandler>(handler => handler.HandleMoneyChanged(_value));
    }

    public void HandleMoneyEarned(int value)
    {
        _value += value;
        _eventBus.RaiseEvent<IMoneyValueHandler>(handler => handler.HandleMoneyChanged(_value));
    }
}
