using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<EventHolder>()
            .FromNew()
            .AsSingle();
        
        Container.BindInterfacesAndSelfTo<Clicker>()
            .FromNew()
            .AsSingle();
        
        Container.BindInterfacesAndSelfTo<Wallet>()
            .FromNew()
            .AsSingle();
        
        Container.BindInterfacesAndSelfTo<EnemyHolder>()
            .FromNew()
            .AsSingle();
    }
}