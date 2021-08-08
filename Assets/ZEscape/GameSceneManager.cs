using Game.Gui;
using System;
using Zenject;
using ZEscape.Camera;
using ZEscape.Settings;

namespace Game
{
    public class GameSceneManager : ITickable, IInitializable, IDisposable
    {

        [Inject] private GameCamera _camera;
        [Inject] private SceneSettings _settings;
        [Inject] private GuiHandler _gui; 

        private enum GameState
        {
            Start,
            Game,
            Win,
            Lose
        }

        // private GameState CurrentGameState = GameState.Start;
        public void Initialize()
        {
            
        }

        public void Tick()
        {

        }

        public void Dispose()
        {

        }
    }
}