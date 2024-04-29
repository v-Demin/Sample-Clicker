public class BattleMapObject : IMapObject
{
    private BattleRequestData _data;
    private EventBus _globalEventBus;
    
    public BattleMapObject(BattleRequestData data, EventBus globalEventBus)
    {
        _data = data;
        _globalEventBus = globalEventBus;
    }
    
    public void Interact()
    {
        _globalEventBus.RaiseEvent<IBattleRequestHandler>(handler => handler.HandleBattleRequest(_data));
    }
}
