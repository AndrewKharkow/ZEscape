using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Character
{
    public class StickmanZombie : CharacterBase
    {
        public void Kill()
        {
            Destroy(gameObject);
        }
    }
}