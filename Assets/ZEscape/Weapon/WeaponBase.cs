using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Weapon
{
    public abstract class WeaponBase : MonoBehaviour
    {
        [SerializeField] private GameObject _muzzleFlash;

        private void Update()
        {
            if(Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _muzzleFlash.SetActive(true);
                        break;
                    case TouchPhase.Ended:
                        _muzzleFlash.SetActive(false);
                        break;
                }
            }
        }
    }
}