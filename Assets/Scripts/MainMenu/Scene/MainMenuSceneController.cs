using System;
using UnityEngine;
using Zenject;

public class MainMenuSceneController : MonoBehaviour
{
    [Inject] private readonly EventBus _globalEventBus;

    [SerializeField] private GameObject _settingsCanvas;
    [SerializeField] private GameObject _authorsCanvas;

    private void Start()
    {
        //[Todo]: Проверить есть ли сохранённая игра, если есть, активировать кнопку "продолжить"
        //[Todo]: Передать дату в кнопку "продолжить"
    }

    public void HandleContinueBattleClicked()
    {
        _globalEventBus.RaiseEvent<IGameNewStartedHanler>(handler => handler.HandleGameStarted());
    }
    
    public void HandleNewGameBattleClicked()
    {
        //[Todo]: Обратиться к сейвам и загрузить
        _globalEventBus.RaiseEvent<IGameResumedHanler>(handler => handler.HandleGameResumed(new MainCycle.CycleData()));
    }

    public void HandleSettingsButtonClicked()
    {
        //[Todo]: заменить на красивый показ
        _authorsCanvas.SetActive(false);
        _settingsCanvas.SetActive(!_settingsCanvas.activeSelf);
    }
    
    public void HandleAuthorsButtonClicked()
    {
        //[Todo]: заменить на красивый показ
        _settingsCanvas.SetActive(false);
        _authorsCanvas.SetActive(!_authorsCanvas.activeSelf);
    }
    
    public void HandleQuitBattleClicked()
    {
        _globalEventBus.RaiseEvent<IGameAbortedHanler>(handler => handler.HandleGameAborted());
        Application.Quit();
    }
}
