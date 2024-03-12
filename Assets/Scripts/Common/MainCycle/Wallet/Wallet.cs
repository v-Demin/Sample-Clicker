using Zenject;

public class Wallet : IInitializable, IMoneyEarnedHandler, IMoneySpentHandler
{
    [Inject] private readonly EventHolder _eventHolder;
    
    public int Value => _value;
    private int _value;

    public void Initialize()
    {
        _eventHolder.Subscribe(this);
        _eventHolder.RaiseEvent<IMoneyValueHandler>(handler => handler.HandleMoneyInitialized(_value));
    }
    
    public void HandleTryToSpendMoney(int value)
    {
        if (_value < value) return;

        _value -= value;
        _eventHolder.RaiseEvent<IMoneyValueHandler>(handler => handler.HandleMoneyChanged(_value));
    }

    public void HandleMoneyEarned(int value)
    {
        _value += value;
        _eventHolder.RaiseEvent<IMoneyValueHandler>(handler => handler.HandleMoneyChanged(_value));
    }
}
