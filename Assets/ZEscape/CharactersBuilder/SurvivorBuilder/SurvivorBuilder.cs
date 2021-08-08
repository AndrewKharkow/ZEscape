using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZEscape.Character;
using ZEscape.Helicopter;
using ZEscape.Settings;

namespace ZEscape.CharacterBuilder
{
    public class SurvivorBuilder : MonoBehaviour
    {
        [Inject] private SceneSettings _settings;
        [Inject] private GameHelicopter _helicopter;
        [SerializeField] private int _survivorsCount;
        [SerializeField] private List<CharacterBase> _survivors;

        public event Action CharactersAreOver;
        private Transform Transform => transform;

        private void Start()
        {
            for(int i = 0; i < _survivorsCount; i++)
            {
                CharacterBase survivor;
                survivor = Instantiate(_settings.SurvivorPrefab, transform);
                survivor.gameObject.tag = "Survivor";
                _survivors.Add(survivor); 
            }
        }

        public void RemoveCharacterFromList(CharacterBase survivor)
        {
            _survivors.Remove(survivor);
            if(_survivors.Count == 0)
            {
                CharactersAreOver?.Invoke();
            }
        }

        public void RunToEscape()
        {
            for (int i = 0; i < _survivors.Count; i++)
            {
                _survivors[i].SendCharacterToPoint(_helicopter.transform);
            }
        }
    }
}