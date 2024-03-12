using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnemyView : MonoBehaviour, IInitializable, IEnemyValueHandler
{
    [Inject] private readonly EventHolder _eventHolder;
    [SerializeField] private Slider _healthSlider;

    private Enemy _enemy;
    
    [Inject]
    public void Initialize()
    {
        _eventHolder.Subscribe(this);
    }
    
    public void HandleEnemySpawned(Enemy enemy)
    {
        _enemy = enemy;
        Refresh(1f);
    }

    public void HandleEnemyHealthChanged(float totalHealth)
    {
        Refresh(totalHealth / _enemy.MaxHealth);
    }

    public void HandleEnemyDied(Enemy enemy)
    {
        
    }

    private void Refresh(float healthProportion)
    {
        _healthSlider.value = healthProportion;
    }
}
