using System.Collections.Generic;

public interface IBattleRequestHandler : ISubscriber
{
    void HandleBattleRequest(BattleRequestData data);
}

public class BattleRequestData
{
    public PlayerData PlayerData;
    public List<Enemy> Enemies;

    public BattleRequestData(PlayerData playerData, List<Enemy> enemies)
    {
        PlayerData = playerData;
        Enemies = enemies;
    }
}