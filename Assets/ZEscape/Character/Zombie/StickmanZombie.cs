using UnityEngine;

namespace ZEscape.Character
{
    public class StickmanZombie : CharacterBase
    {
        public void Kill()
        {
            Destroy(gameObject);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Survivor")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}