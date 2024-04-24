public interface IGameResumedHanler : ISubscriber
{
    void HandleGameResumed(MainCycle.CycleData data);
}
