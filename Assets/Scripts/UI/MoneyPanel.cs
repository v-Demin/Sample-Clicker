using TMPro;
using UnityEngine;
using Zenject;

public class MoneyPanel : MonoBehaviour, IMoneyChangedHandler
{
    [Inject] private readonly EventHolder _eventHolder;
    
    [SerializeField] private TextMeshProUGUI _moneyText;

    private void Start()
    {
        _eventHolder.Subscribe(this);
    }

    public void HandleMoneyChanged(int totalValue)
    {
        _moneyText.text = totalValue.ToString();
    }
}
