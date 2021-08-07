using System;
using Zenject;

namespace Game
{
    public class GameSceneManager : ITickable, IInitializable, IDisposable
    {
        private enum GameState
        {
            Start,
            Game,
            Win,
            Lose
        }

       // private GameState CurrentGameState = GameState.Start;

        public void Tick()
        {

        }

        public void Initialize()
        {

        }

        public void Dispose()
        {

        }
    }
}