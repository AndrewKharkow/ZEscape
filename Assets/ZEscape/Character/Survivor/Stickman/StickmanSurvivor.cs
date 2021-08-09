using UnityEngine;
using ZEscape.CharacterBuilder;

namespace ZEscape.Character
{
    public class StickmanSurvivor : CharacterBase
    {
        private Animator Animator => GetComponent<Animator>();
        private SurvivorBuilder _survivorBuilder => transform.parent.GetComponent<SurvivorBuilder>();
        public override void SendCharacterToPoint(Transform targetPoint)
        {
            base.SendCharacterToPoint(targetPoint);
            Animator.SetTrigger("Run");
        }

        private void OnDestroy()
        {
            _survivorBuilder.RemoveCharacterFromList(this);
        }
    }
}