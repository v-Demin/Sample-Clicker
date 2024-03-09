public interface IMoneyChangedHandler : ISubscriber
{
    void HandleMoneyChanged(int totalValue);
}
