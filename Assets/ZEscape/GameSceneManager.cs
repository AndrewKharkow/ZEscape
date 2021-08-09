using System;
using UnityEngine;
using Zenject;
using ZEscape.Character;
using ZEscape.CharacterBuilder;
using ZEscape.Settings;
using ZEscape.VFX;
using ZEscape.Gui;
using ZEscape.Camera;

namespace ZEscape
{
    public class GameSceneManager : ITickable, IInitializable, IDisposable
    {

        [Inject] private GameCamera _camera;
        [Inject] private SceneSettings _settings;
        [Inject] private GuiHandler _gui;
        [Inject] private SurvivorBuilder _survivorBuilder;

        [Inject] private BulletImpactEffect.Factory _bulletImpactFactory;
        [Inject] private BonusEffect.Factory _bonusFactory;

        private const float FireRate = 0.1f;
        private float _fireRateTimer;


        private enum GameState
        {
            Start,
            Game,
            Win,
            Lose
        }

        public void Initialize()
        {
            _gui.Start.StartGame += OnStartGame;
            _gui.Game.FingerTap += OnFingerTap;
            _gui.FadeEffect();
        }

        private void OnStartGame()
        {
            _survivorBuilder.RunToEscape();
            _gui.SetGuiState(GuiHandler.GuiState.Game);
            _camera.SetCameraState(GameCamera.CameraState.Game);
            _gui.FadeEffect();

        }

        private void OnFingerTap(Vector2 tapPosition)
        {
            RaycastHit hit;
            Ray ray = _camera.Camera.ScreenPointToRay(tapPosition);

            if (Physics.Raycast(ray, out hit))
            {
                _camera.WeaponPoint.LookAt(hit.point);
                if (_fireRateTimer > 0)
                {
                    _fireRateTimer -= Time.deltaTime;
                }
                if (_fireRateTimer <= 0)
                {
                    _bulletImpactFactory.Create(hit.point);

                    if (hit.transform.gameObject.tag == "Zombie")
                    {
                        StickmanZombie zombie = hit.transform.gameObject.GetComponent<StickmanZombie>();
                        _bonusFactory.Create(zombie.transform.position);
                        zombie.Kill();
                    }
                    _fireRateTimer = FireRate;
                }
            }
        }

        public void Tick()
        {

        }

        public void Dispose()
        {
            _gui.Start.StartGame += OnStartGame;
            _gui.Game.FingerTap += OnFingerTap;
        }
    }
}