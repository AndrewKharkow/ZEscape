using Zenject;
using Game.CharacterBuilder;
using Game.Settings;
using ZEscape.Gui;
using ZEscape;
using ZEscape.Camera;
using ZEscape.Helicopter;

public class GameContentInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SceneSettings>().FromComponentInHierarchy(true).AsSingle();
        Container.Bind<GameCamera>().FromComponentInHierarchy(true).AsSingle();
        Container.Bind<GuiHandler>().FromComponentInHierarchy(true).AsSingle();
        Container.Bind<SurvivorBuilder>().FromComponentInHierarchy(true).AsSingle();
        Container.Bind<GameHelicopter>().FromComponentInHierarchy(true).AsSingle();

        Container.BindInterfacesAndSelfTo<GameSceneManager>().AsSingle();
    }
}