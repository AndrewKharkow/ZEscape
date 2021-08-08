using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZEscape.Character;
using ZEscape.Weapon;

namespace ZEscape.Settings
{
    public class SceneSettings : MonoBehaviour
    {
        [Header("CHARACTERS")]
        public CharacterBase SurvivorPrefab;
        public CharacterBase ZombiePrefab;

        [Space(5)]

        [Header("WEAPON")]
        public WeaponBase GunPrefab;

        [Space(5)]

        [Header("CHARACTER PARAMETERS")]
        public float SurvivorsSpeed;
        public float ZombieSpeed;

        [Space(5)]

        [Header("PERFOMANCE SETTINGS")]
        public int TargetFramesPerSecond;
        public enum Tags
        {
            Survivor = 0,
            Zombie = 1
        }
    }
}