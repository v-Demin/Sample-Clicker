using UnityEngine;
using Zenject;

public class MainCycle : IInitializable, IPlayerLoseHandler, IBattleRequestHandler, IBattleAbortedHandler, IBattleEndedHandler
{
    private readonly EventBus _globalBus;
    private readonly BattleSceneInitiator _battleSceneInitiator;
    private readonly MapSceneInitiator _mapSceneInitiator;

    private CycleData _cycleData = new CycleData();
    
    [Inject]
    private MainCycle(EventBus globalBus, BattleSceneInitiator battleSceneInitiator, MapSceneInitiator mapSceneInitiator)
    {
        _globalBus = globalBus;
        _battleSceneInitiator = battleSceneInitiator;
        _mapSceneInitiator = mapSceneInitiator;
    }

    public void Initialize()
    {
        _globalBus.Subscribe(this);
    }

    public void HandlePlayerLose()
    {
        "Помер и помер".Log(Color.cyan);
    }

    public void HandleBattleRequest(BattleRequestData data)
    {
        _battleSceneInitiator.StartBattle(data);
    }

    public void HandleBattleAbort()
    {
        "Кто, нахер?".Log(Color.blue);
    }

    public void HandleBattleEnded()
    {
        _mapSceneInitiator.Resume();
    }
    
    private class CycleData
    {
        
    }
}
