using UnityEngine;
using Zenject;

public class FallbackBattleSceneController : MonoBehaviour
{
    [Inject] private readonly BattleSceneInitiator _sceneInitiator;
    [Inject] private readonly EventBus _globalEventBus;
    
    public void ValidateSceneStart()
    {
        if (_sceneInitiator.Data == null)
        {
            _globalEventBus.RaiseEvent<IBattleAbortedHandler>(handler => handler.HandleBattleAbort());
        }
    }
}
