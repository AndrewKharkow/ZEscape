using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZEscape.Character;
using ZEscape.CharacterBuilder;

namespace ZEscape.Helicopter
{
    [RequireComponent(typeof(BoxCollider))]
    public class GameHelicopter : MonoBehaviour
    {
        [Inject] private SurvivorBuilder _survivorBuilder;
        public int SurvivorsCount;
        private void Awake()
        {
            GetComponent<BoxCollider>().isTrigger = true;
            _survivorBuilder.CharactersAreOver += _survivorBuilder_CharactersAreOver;
        }

        private void _survivorBuilder_CharactersAreOver()
        {
            Debug.Log("CharactersAreOver");
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Survivor")
            {
                CharacterBase character = other.GetComponent<CharacterBase>();
                _survivorBuilder.RemoveCharacterFromList(character);
                SurvivorsCount++;
                Destroy(other.gameObject);
            }
        }
    }
}