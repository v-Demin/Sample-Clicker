using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnemyView : MonoBehaviour, IInitializable, IEnemyValueHandler
{
    [Inject] private readonly EventHolder _eventHolder;
    
    [Header("SliderSettings")]
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private float _baseTime;
    [SerializeField] private Ease _ease;

    private Tween _hpTweenCash;

    private Enemy _enemy;

    [Inject]
    public void Initialize()
    {
        _eventHolder.Subscribe(this);
    }
    
    public void HandleEnemySpawned(Enemy enemy)
    {
        _enemy = enemy;
        _hpTweenCash.Kill();
        _healthSlider.value = 1f;
    }

    public void HandleEnemyHealthChanged(float totalHealth)
    {
        TakeDamage(totalHealth / _enemy.MaxHealth);
    }

    public void HandleEnemyDied(Enemy enemy)
    {

    }

    private void TakeDamage(float healthProportion)
    {
        _hpTweenCash = DOVirtual.Float(_healthSlider.value, healthProportion, _baseTime, value => _healthSlider.value = value)
            .SetEase(_ease);
    }
}
