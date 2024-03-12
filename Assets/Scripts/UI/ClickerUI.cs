using TMPro;
using UnityEngine;
using Zenject;

public class ClickerUI : MonoBehaviour, IInitializable, ICliclerValuesHandler
{
    [Inject] private readonly EventHolder _eventHolder;

    [SerializeField] private TextMeshProUGUI _levelLabel;
    [SerializeField] private TextMeshProUGUI _damageLabel;
    [SerializeField] private TextMeshProUGUI _priceLabel;
    
    [Inject]
    public void Initialize()
    {
        _eventHolder.Subscribe(this);
    }

    public void HandleUpdateClicked()
    {
        _eventHolder.RaiseEvent<IClickerUpdateHandler>(handler => handler.TryUpgrade());
    }

    public void HandleClickerInitialized(int level, float damage, int nextPrice)
    {
        Refresh(level, damage, nextPrice);
    }

    public void HandleClickerLevelUpdated(int level, float damage, int nextPrice)
    {
        Refresh(level, damage, nextPrice);
    }

    private void Refresh(int level, float damage, int nextPrice)
    {
        _levelLabel.text = $"LVL: {level}";
        _damageLabel.text = $"DPC: {damage}";
        _priceLabel.text = $"Cost: {nextPrice}";
    }
}
