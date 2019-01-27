using System;
using Objects;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        //PlayerHealth playerHealth;
        private EnemyHealth enemyHealth;
        private NavMeshAgent nav;

        public EnemyPriority enemyPriority;

        void Awake()
        {
            enemyHealth = GetComponent<EnemyHealth>();
            nav = GetComponent<NavMeshAgent>();
        }

        void FixedUpdate()
        {
            if (enemyHealth.currentHealth <= 0)
            {
                return;
            }

            Behaviour closestTarget; 
            switch (enemyPriority)
            {
                case EnemyPriority.STEALABLE:
                    closestTarget = EnemyTargetFinder.FindClosestStealable(transform.position);
                    break;
                case EnemyPriority.PLAYER:
                default:
                    closestTarget = EnemyTargetFinder.FindClosestEnemy(transform.position);
                    break;
            }

            nav.destination = closestTarget.transform.position;
        }

        private void OnDrawGizmosSelected()
        {
            if (Application.isPlaying)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(nav.destination, 0.5f);
            }
        }
    }
}