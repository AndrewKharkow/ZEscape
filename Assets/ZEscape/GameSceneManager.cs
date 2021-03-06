using System;
using UnityEngine;
using Zenject;
using ZEscape.Gui;
using ZEscape.Camera;
using ZEscape.Helicopter;
using ZEscape.VFX;
using ZEscape.Settings;
using ZEscape.CharacterBuilder;
using ZEscape.Character;

namespace ZEscape
{
    public class GameSceneManager : IInitializable, IDisposable
    {

        [Inject] private GameCamera _camera;
        [Inject] private SceneSettings _settings;
        [Inject] private GuiHandler _gui;
        [Inject] private SurvivorBuilder _survivorBuilder;
        [Inject] private BulletImpactEffect.Factory _bulletImpactFactory;
        [Inject] private BonusEffect.Factory _bonusFactory;
        [Inject] private GameHelicopter _helicopter;

        private const float FireRate = 0.1f;
        private float _fireRateTimer;

        public void Initialize()
        {
            Application.targetFrameRate = _settings.TargetFramesPerSecond;

            _gui.Start.StartGame += OnStartGame;
            _gui.Game.FingerTap += OnFingerTap;

            _survivorBuilder.CharactersAreOver += OnCharactersAreOver;

            _gui.FadeEffect();
        }

        private void OnCharactersAreOver()
        {
            if(_helicopter.SurvivorsCount == 0)
            {
                _camera.SetCameraState(GameCamera.CameraState.SlowMotion);
                _gui.SetGuiState(GuiHandler.GuiState.Lose);
            }
            else
            {
                _camera.SetCameraState(GameCamera.CameraState.Heli);
                _gui.SetGuiState(GuiHandler.GuiState.Win);
                _helicopter.Fly();
            }
        }

        private void OnStartGame()
        {
            _survivorBuilder.RunToEscape();
            _camera.SetCameraState(GameCamera.CameraState.Game);
            _gui.SetGuiState(GuiHandler.GuiState.Game);
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

        public void Dispose()
        {
            _gui.Start.StartGame += OnStartGame;
            _gui.Game.FingerTap += OnFingerTap;
        }
    }
}