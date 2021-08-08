using Game.Gui;
using UnityEngine;
using Zenject;
using ZEscape.Camera;
using ZEscape.CharacterBuilder;
using ZEscape.Settings;

public class GameContentInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<SceneSettings>().FromComponentInHierarchy(true).AsSingle();
        Container.Bind<GameCamera>().FromComponentInHierarchy(true).AsSingle();
        Container.Bind<GuiHandler>().FromComponentInHierarchy(true).AsSingle();
        Container.Bind<SurvivorBuilder>().FromComponentInHierarchy(true).AsSingle();
    }
}