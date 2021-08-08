using Game.Gui;
using System;
using UnityEngine;
using Zenject;
using ZEscape.Camera;
using ZEscape.Character;
using ZEscape.CharacterBuilder;
using ZEscape.Settings;
using ZEscape.VFX;

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
                if(_fireRateTimer > 0)
                {
                    _fireRateTimer -= Time.deltaTime;
                }
                if(_fireRateTimer <= 0)
                {
                    _bulletImpactFactory.Create(hit.point);

                    if(hit.transform.gameObject.tag == "Zombie")
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
            if (Input.GetMouseButtonDown(0))
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