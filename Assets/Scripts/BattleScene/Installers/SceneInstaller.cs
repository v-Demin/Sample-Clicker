using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<Clicker>()
            .FromNew()
            .AsSingle();
        
        Container.BindInterfacesAndSelfTo<EnemyHolder>()
            .FromNew()
            .AsSingle();
    }
}