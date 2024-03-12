using TMPro;
using UnityEngine;
using Zenject;

public class MoneyPanel : MonoBehaviour, IInitializable, IMoneyValueHandler
{
    [Inject] private readonly EventHolder _eventHolder;
    
    [SerializeField] private TextMeshProUGUI _moneyText;
    
    [Inject]
    public void Initialize()
    {
        _eventHolder.Subscribe(this);
    }

    public void HandleMoneyChanged(int totalValue)
    {
        _moneyText.text = totalValue.ToString();
    }

    public void HandleMoneyInitialized(int totalValue)
    {
        _moneyText.text = totalValue.ToString();
    }
}
