using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZEscape.Helicopter;
using ZEscape.Settings;
using ZEscape.Character;

namespace ZEscape.CharacterBuilder
{
    public class EnemyBuilder : MonoBehaviour
    {
        [SerializeField] private int _zombieCount;
        [SerializeField] private SurvivorChecker _survivorChecker;
        [Inject] private SceneSettings _settings;
        [Inject] private GameHelicopter _helicopter;
        [SerializeField] private List<CharacterBase> _zombies;
        private Transform Transform => transform;

        private void Awake()
        {
            _survivorChecker.SurvivorOnPlace += OnSurvivorOnPlace;
        }

        private void OnSurvivorOnPlace()
        {
            for (int i = 0; i < _zombies.Count; i++)
            {
                _zombies[i].gameObject.SetActive(true);
                _zombies[i].SendCharacterToPoint(_helicopter.transform);
            }
        }

        private void Start()
        {
            for (int i = 0; i < _zombieCount; i++)
            {
                CharacterBase zombie;
                zombie = Instantiate(_settings.ZombiePrefab, transform);
                zombie.gameObject.SetActive(false);
                zombie.gameObject.tag = "Zombie";
                _zombies.Add(zombie);
            }
        }
        private void OnDisable()
        {
            _survivorChecker.SurvivorOnPlace += OnSurvivorOnPlace;
        }
    }
}