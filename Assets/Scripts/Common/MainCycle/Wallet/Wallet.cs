using Zenject;

public class Wallet : IMoneyEarnedHandler
{
    [Inject] private readonly EventHolder _eventHolder;
    
    private int _value;

    public void Init()
    {
        _eventHolder.Subscribe(this);
    }

    public void HandleMoneyEarned(int value)
    {
        _value += value;
        _eventHolder.RaiseEvent<IMoneyChangedHandler>(halder => halder.HandleMoneyChanged(_value));
    }
}
