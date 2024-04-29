public interface IGameResumedHanler : ISubscriber
{
    void HandleGameResumed(GameCycle.CycleData data);
}
