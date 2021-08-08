using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZEscape.Character
{
    public class StickmanZombie : CharacterBase
    {
        public void Kill()
        {
            Destroy(gameObject);
        }
    }
}