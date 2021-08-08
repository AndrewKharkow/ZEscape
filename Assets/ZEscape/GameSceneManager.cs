using Game.Gui;
using System;
using UnityEngine;
using Zenject;
using ZEscape.Camera;
using ZEscape.CharacterBuilder;
using ZEscape.Settings;

namespace ZEscape
{
    public class GameSceneManager : ITickable, IInitializable, IDisposable
    {

        [Inject] private GameCamera _camera;
        [Inject] private SceneSettings _settings;
        [Inject] private GuiHandler _gui;
        [Inject] private SurvivorBuilder _survivorBuilder;

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
            _gui.Game.FingerTap += OnFingerTap;
        }

        private void OnFingerTap(Vector2 tapPosition)
        {
            RaycastHit hit;
            Ray ray = _camera.Camera.ScreenPointToRay(tapPosition);

            if (Physics.Raycast(ray, out hit))
            {
                _camera.WeaponPoint.LookAt(hit.point);
            }
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("RUN");
                _survivorBuilder.RunToEscape();
            }
        }

        public void Dispose()
        {

        }
    }
}