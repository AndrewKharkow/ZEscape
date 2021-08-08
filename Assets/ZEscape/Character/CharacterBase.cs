using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ZEscape.Character
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    [RequireComponent(typeof(NavMeshAgent))]

    public abstract class CharacterBase : MonoBehaviour
    {
        public NavMeshAgent NavMeshAgent => GetComponent<NavMeshAgent>();

        public virtual void SendCharacterToPoint(Transform targetPoint)
        {
            NavMeshAgent.destination = targetPoint.position;
        }
    }
}