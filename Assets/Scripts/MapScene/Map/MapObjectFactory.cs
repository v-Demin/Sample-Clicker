using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MapObjectFactory : MonoBehaviour
{
    [Inject] private readonly EventBus _globalEventBus;
    
    [SerializeField] private MapObjectView _battleObjectView;
    [SerializeField] private MapUI _mapUI;

    private Dictionary<Type, MapObjectView> _viewDictionary;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _viewDictionary  = new()
        {
            {typeof(BattleMapObject), _battleObjectView}
        };
    }

    public MapObjectView GenerateBattle(float value = 0f)
    {
        //[Todo]: замена пустого листа на внешний сервис генерации
        var mapObject = new BattleMapObject(new BattleRequestData(new List<Enemy>()), _globalEventBus);
        
        var view = GenerateView<BattleMapObject>();
        view.Init(mapObject);
        
        return view;
    }

    private MapObjectView GenerateView<T>() where T : IMapObject
    {
        var view = Instantiate(_viewDictionary[typeof(T)], _mapUI.Root);
        _mapUI.AttachObject(view);

        return view;
    }
}
