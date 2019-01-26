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

            var closestEnemy = EnemyTargetFinder.FindClosestEnemy(transform.position);
            nav.destination = closestEnemy.transform.position;
        }
    }
}