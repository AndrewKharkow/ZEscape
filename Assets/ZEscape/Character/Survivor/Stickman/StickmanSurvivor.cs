using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZEscape.Character
{
    public class StickmanSurvivor : CharacterBase
    {
        private Animator Animator => GetComponent<Animator>();
        public override void SendCharacterToPoint(Transform targetPoint)
        {
            base.SendCharacterToPoint(targetPoint);
            Animator.SetTrigger("Run");
        }
    }
}