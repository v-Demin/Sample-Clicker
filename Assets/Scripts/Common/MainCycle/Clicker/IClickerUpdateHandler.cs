public interface IClickerUpdateHandler : ISubscriber
{
    void TryUpgrade(int times = 1);
    void ForceUpgrade(int times = 1);
}
