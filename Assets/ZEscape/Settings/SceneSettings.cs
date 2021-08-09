using UnityEngine;
using Game.Weapon;
using ZEscape.Character;

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

        [Header("PERFOMANCE SETTINGS")]
        public int TargetFramesPerSecond;

    }
}