public interface IBattleRequestHandler : ISubscriber
{
    void HandleBattleRequest(BattleRequestData data);
}

