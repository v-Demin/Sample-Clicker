using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<EventBus>()
            .FromNew()
            .AsSingle();
        
        Container.BindInterfacesAndSelfTo<Wallet>()
            .FromNew()
            .AsSingle();
        
        Container.BindInterfacesAndSelfTo<MainMenuSceneInitiator>()
            .FromNew()
            .AsSingle();
        
        Container.BindInterfacesAndSelfTo<MapSceneInitiator>()
            .FromNew()
            .AsSingle();
        
        Container.BindInterfacesAndSelfTo<BattleSceneInitiator>()
            .FromNew()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<MainCycle>()
            .FromNew()
            .AsSingle();
    }
}