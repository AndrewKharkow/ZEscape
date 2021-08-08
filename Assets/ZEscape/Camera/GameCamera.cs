using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZEscape.Settings;

namespace ZEscape.Camera
{
    public class GameCamera : MonoBehaviour
    {
        [Inject] private SceneSettings _settings;

        public Transform WeaponPoint = null;
        public UnityEngine.Camera Camera => GetComponent<UnityEngine.Camera>();

        private void Start()
        {
            Instantiate(_settings.GunPrefab, WeaponPoint);
        }
    }
}