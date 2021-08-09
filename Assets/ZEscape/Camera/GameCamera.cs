using UnityEngine;
using Zenject;
using ZEscape.Gui;
using ZEscape.Settings;

namespace ZEscape.Camera
{
    public class GameCamera : MonoBehaviour
    {
        public enum CameraState
        {
            Game,
            SlowMotion,
            Heli
        }

        [Inject] private SceneSettings _settings;
        [Inject] private GuiHandler _gui;
        private Animator Animator => GetComponent<Animator>();
        public Transform WeaponPoint = null;
        public UnityEngine.Camera Camera => GetComponent<UnityEngine.Camera>();


        private void Start()
        {
            Instantiate(_settings.GunPrefab, WeaponPoint);
            Time.timeScale = 1;
        }
        public void SetCameraState(CameraState cameraState)
        {
            switch (cameraState)
            {
                case CameraState.Game:
                    _gui.FadeEffect();
                    Animator.SetTrigger("Start");
                    Time.timeScale = 1;
                    break;
                case CameraState.SlowMotion:
                    _gui.FadeEffect();
                    Time.timeScale = 0.5f;
                    break;
                case CameraState.Heli:
                    _gui.FadeEffect();
                    Animator.SetTrigger("Heli");
                    Time.timeScale = 1;
                    break;
            }
        }
    }
}