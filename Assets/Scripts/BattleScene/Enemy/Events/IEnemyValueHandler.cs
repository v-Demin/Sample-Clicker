public interface IEnemyValueHandler : ISubscriber
{
    void HandleEnemySpawned(Enemy enemy);
    void HandleEnemyHealthChanged(float totalHealth);
    void HandleEnemyDied(Enemy enemy);
}
