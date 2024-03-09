using Zenject;

public class Clicker : IEnemyClickHandler
{
    [Inject] private readonly EventHolder _eventHolder;

    public void Init()
    {
        _eventHolder.Subscribe(this);
    }
    
    public void HandleEnemyClick()
    {
        _eventHolder.RaiseEvent<IMoneyEarnedHandler>(handler => handler.HandleMoneyEarned(10));
    }
}
