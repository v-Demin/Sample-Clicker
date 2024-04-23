public interface ICliclerValuesHandler : ISubscriber
{
    void HandleClickerInitialized(int level, float damage, int nextPrice);
    void HandleClickerLevelUpdated(int level, float damage, int nextPrice);
}
