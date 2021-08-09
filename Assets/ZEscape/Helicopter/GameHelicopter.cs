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
        private Animator Animator => GetComponent<Animator>();
        public int SurvivorsCount;

        private void Awake()
        {
            GetComponent<BoxCollider>().isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Survivor")
            {
                CharacterBase character = other.GetComponent<CharacterBase>();
                SurvivorsCount++;
                Destroy(other.gameObject);
            }
        }

        public void Fly()
        {
            Animator.SetTrigger("Fly");
        }
    }
}