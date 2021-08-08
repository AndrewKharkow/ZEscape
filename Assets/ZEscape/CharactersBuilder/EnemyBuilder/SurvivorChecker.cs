using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZEscape.CharacterBuilder
{
    [RequireComponent(typeof(BoxCollider))]
    public class SurvivorChecker : MonoBehaviour
    {
        private BoxCollider BoxCollider => GetComponent<BoxCollider>();
        public event Action SurvivorOnPlace;
        private MeshRenderer MeshRenderer => GetComponent<MeshRenderer>();
        private void Start()
        {
            BoxCollider.isTrigger = true;
            MeshRenderer.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Survivor")
            {
                SurvivorOnPlace?.Invoke();
                gameObject.SetActive(false);
            }
        }
    }
}