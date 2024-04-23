public interface IMoneyValueHandler : ISubscriber
{
    void HandleMoneyChanged(int totalValue);
    void HandleMoneyInitialized(int totalValue);
}
