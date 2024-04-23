using UnityEngine;
using Zenject;

public class EnemyHolder : IInitializable, IEnemyDamageHandler
{
    [Inject] private EventBus _eventBus;

    private Enemy _enemy = new Enemy();
    
    public void Initialize()
    {
        _eventBus.Subscribe(this);
        Respawn();
    }
    
    public void HandleTakeDamage(float damage)
    {
        _enemy.Health -= damage;
        _eventBus.RaiseEvent<IEnemyValueHandler>(handler => handler.HandleEnemyHealthChanged(_enemy.Health));

        if (_enemy.Health <= 0f)
        {
            _eventBus.RaiseEvent<IEnemyValueHandler>(handler => handler.HandleEnemyDied(_enemy));
            _eventBus.RaiseEvent<IMoneyEarnedHandler>(handler => handler.HandleMoneyEarned(_enemy.Reward));
            Respawn();
        }
    }

    private void Respawn()
    {
        _enemy = new Enemy();
        _eventBus.RaiseEvent<IEnemyValueHandler>(handler => handler.HandleEnemySpawned(_enemy));
    }
}
