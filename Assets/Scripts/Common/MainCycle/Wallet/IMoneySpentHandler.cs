public interface IMoneySpentHandler : ISubscriber
{
    void HandleTryToSpendMoney(int value);
}
