using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZEscape.Character;
using ZEscape.Settings;

namespace ZEscape.CharacterBuilder
{
    public class SurvivorBuilder : MonoBehaviour
    {
        [Inject] private SceneSettings _settings;
        [SerializeField] private int _survivorsCount;
        [SerializeField] private List<CharacterBase> _survivors;

        private Transform Transform => transform;

        private void Start()
        {
            for(int i = 0; i < _survivorsCount; i++)
            {
                CharacterBase survivor;
                survivor = Instantiate(_settings.SurvivorPrefab, transform);
                _survivors.Add(survivor); 
            }
        }
    }
}