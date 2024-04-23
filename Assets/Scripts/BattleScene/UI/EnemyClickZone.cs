using UnityEngine;
using Zenject;

public class EnemyClickZone : MonoBehaviour
{
    [Inject] private readonly EventBus _eventBus;

    public void HandleClick()
    {
        "Клякнули".Log(Color.cyan);
        _eventBus.RaiseEvent<IEnemyClickHandler>(handler => handler.HandleEnemyClick());
    }
}
