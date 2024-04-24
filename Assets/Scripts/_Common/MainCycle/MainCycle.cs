using UnityEngine;
using Zenject;

public class MainCycle : IInitializable, IPlayerLoseHandler, IBattleCommonHandler, IGameCommonHanler
{
    private readonly EventBus _globalBus;
    private readonly MainMenuSceneInitiator _menuSceneInitiator;
    private readonly MapSceneInitiator _mapSceneInitiator;
    private readonly BattleSceneInitiator _battleSceneInitiator;

    private CycleData _cycleData = new CycleData();
    
    [Inject]
    private MainCycle(EventBus globalBus, BattleSceneInitiator battleSceneInitiator, MapSceneInitiator mapSceneInitiator, MainMenuSceneInitiator menuSceneInitiator)
    {
        _globalBus = globalBus;
        _battleSceneInitiator = battleSceneInitiator;
        _mapSceneInitiator = mapSceneInitiator;
        _menuSceneInitiator = menuSceneInitiator;
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
        _menuSceneInitiator.LoadScene();
    }

    public void HandleBattleEnded()
    {
        _mapSceneInitiator.Resume();
    }

    public void HandleGameAborted()
    {
        //[Todo]: Сохранить игру(?)
        "Пока".Log(Color.green);
    }

    public void HandleGameResumed(CycleData data)
    {
        _cycleData = data;
        _mapSceneInitiator.Resume();
    }

    public void HandleGameStarted()
    {
        _cycleData = new CycleData();
        _mapSceneInitiator.LoadScene();
    }
    
    public class CycleData
    {
        
    }
}
