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

        [SerializeField] private Transform _weaponPoint = null;

        private void Start()
        {
            Instantiate(_settings.GunPrefab, _weaponPoint);
        }
    }
}