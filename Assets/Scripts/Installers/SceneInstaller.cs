using Zenject;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<EventHolder>()
            .FromNew()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<MainCycle>()
            .FromNew()
            .AsSingle();
    }
}