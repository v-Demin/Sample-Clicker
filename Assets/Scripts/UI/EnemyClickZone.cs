using UnityEngine;
using Zenject;

public class EnemyClickZone : MonoBehaviour
{
    [Inject] private readonly EventHolder _eventHolder;

    public void HandleClick()
    {
        "Клякнули".Log(Color.cyan);
        _eventHolder.RaiseEvent<IEnemyClickHandler>(handler => handler.HandleEnemyClick());
    }
}
