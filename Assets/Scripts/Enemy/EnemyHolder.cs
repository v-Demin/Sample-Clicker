using UnityEngine;
using Zenject;

public class EnemyHolder : IInitializable, IEnemyDamageHandler
{
    [Inject] private EventHolder _eventHolder;

    private Enemy _enemy = new Enemy();
    
    public void Initialize()
    {
        _eventHolder.Subscribe(this);
        Respawn();
    }
    
    public void HandleTakeDamage(float damage)
    {
        _enemy.Health -= damage;
        _eventHolder.RaiseEvent<IEnemyValueHandler>(handler => handler.HandleEnemyHealthChanged(_enemy.Health));

        if (_enemy.Health <= 0f)
        {
            _eventHolder.RaiseEvent<IEnemyValueHandler>(handler => handler.HandleEnemyDied(_enemy));
            _eventHolder.RaiseEvent<IMoneyEarnedHandler>(handler => handler.HandleMoneyEarned(_enemy.Reward));
            Respawn();
        }
    }

    private void Respawn()
    {
        _enemy = new Enemy();
        _eventHolder.RaiseEvent<IEnemyValueHandler>(handler => handler.HandleEnemySpawned(_enemy));
    }
}
